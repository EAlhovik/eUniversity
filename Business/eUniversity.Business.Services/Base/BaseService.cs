using System.Collections.Generic;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services.Base
{
    public abstract class BaseService<T> : IBaseService<T> where T : class,IEntity
    {
        protected IRepository<T> Repository { get; set; }
        protected BaseService(IRepository<T> repository)
        {
            this.Repository = repository;
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
                //                UpdateHistoryInformation(speciality);
            }
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>All entities</returns>
        public IEnumerable<T> All()
        {
            return Repository.All();
        }

        protected virtual T CreateItem()
        {
            return default(T);
        }
    }
}