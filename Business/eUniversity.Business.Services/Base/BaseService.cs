using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Base;
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
        public IEnumerable<T> All()
        {
            return Repository.All();
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
            Repository.Delete(entity);
        }

        protected abstract T CreateItem();
        protected abstract SelectedItemModel CreateSelectedItem(T item);
    }
}