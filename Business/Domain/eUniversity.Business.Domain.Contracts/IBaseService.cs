using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for services
    /// </summary>
    public interface IBaseService<T> where T : class,IEntity
    {
        /// <summary>
        /// Creates the or open.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The entity. Null if entity doesn't exist</returns>
        T CreateOrOpen(long? id);

        /// <summary>
        /// Saves the specified speciality.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(T entity);

        /// <summary>
        /// All instances.
        /// </summary>
        /// <returns>All entities</returns>
        IEnumerable<T> All();

        /// <summary>
        /// Gets the selected item by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Selecte item</returns>
        SelectedItemModel GetSelectedItemById(long id);

        /// <summary>
        /// Delete the entity.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        void Delete(T entity);
    }
}