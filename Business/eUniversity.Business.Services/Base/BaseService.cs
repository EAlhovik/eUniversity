﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Hosting;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.Domain.Entities.Enums;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : class,IEntity
    {
        protected IRepository<T> Repository { get; set; }
        private readonly IAuthorizationService authorizationService;

        protected BaseService(IRepository<T> repository, IAuthorizationService authorizationService = null)
        {
            this.Repository = repository;
            this.authorizationService = authorizationService;
        }

        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of entity.</param>
        /// <returns>
        /// The entity. Null if entity doesn't exist
        /// </returns>
        public T CreateOrOpen(long? id)
        {
            if (id == null || id.Value == 0)
            {
                return CreateItem();
            }
            var item = Repository.GetById(id.Value);
            return item ?? CreateItem();
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Save(T entity)
        {
            Repository.InsertOrUpdate(entity, true);
            if (entity.IsNew())
            {
                TryUpdateCreatedInformation(entity);
            }
            else
            {
                TryUpdateLastModifiedInformation(entity);
            }
            TryUpdateStatus(entity);
        }

        private void TryUpdateStatus(T entity)
        {
            var entityCreated = entity as IHasStatusTracker;
            if (entityCreated != null)
            {
                if (HasAllRequired(entity))
                {
                    entityCreated.Status = EntityStatusEnum.Approved;
                }
                else
                {
                    entityCreated.Status = EntityStatusEnum.Draft;
                }
            }
        }

        private void TryUpdateCreatedInformation(T entity)
        {
            var entityCreated = entity as IHasCreation;
            if (entityCreated != null)
            {
                entityCreated.Created = DateTime.Now;
                entityCreated.CreatedBy = GetUserName();
            }
        }

        private void TryUpdateLastModifiedInformation(T entity)
        {
            var entityChanged = entity as IHasModificatoin;
            if (entityChanged != null)
            {
                entityChanged.LastModified = DateTime.Now;
                entityChanged.LastModifiedBy = GetUserName();
            }
        }

        private string GetUserName()
        {
            if (authorizationService != null && authorizationService.User != null)
            {
                return authorizationService.User.Identity.Name;
            }
            return string.Empty;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>All entities</returns>
        public virtual IEnumerable<T> All()
        {
            return Repository.All();
        }

        protected virtual bool HasAllRequired(T entity)
        {
            return true;
        }

        /// <summary>
        /// Gets the selected item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Selected item</returns>
        public SelectedItemModel GetSelectedItemById(long id)
        {
            var item = Repository.GetById(id);
            return item == null ? null: CreateSelectedItem(item);
        }

        /// <summary>
        /// Delete the entity.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        public void Delete(T entity)
        {
            if (!entity.IsNew())
            {
                TryDelete(entity);
            }
        }

        private void TryDelete(T entity)
        {
            var entityHasDeleted = entity as IHasDeleted;
            if (entityHasDeleted == null)
            {
                Repository.Delete(entity);
            }
            else
            {
                entityHasDeleted.IsDeleted = true;
            }
        }

        /// <summary>
        /// Gets the selected items.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>All selected items</returns>
        /// <exception cref="System.NotImplementedException">if term not null or empry</exception>
        public virtual IEnumerable<SelectedItemModel> GetSelectedItems(string term)
        {
            return Repository.All().Where(Predicate(term)).Select(CreateSelectedItem);
        }

        protected virtual Expression<Func<T, bool>> Predicate(string term)
        {
            return p => true;
        }

        protected virtual T CreateItem()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        protected abstract SelectedItemModel CreateSelectedItem(T item);
    }
}