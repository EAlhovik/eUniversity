using System.Linq;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Data.Contracts
{
    /// <summary>
    /// Interface for repositories (data access services) of the system.
    /// </summary>
    /// <typeparam name="T">Type of entity that repository works with.</typeparam>
    public interface IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Gets all the entities of type T
        /// </summary>
        /// <returns>Result set of all the entities</returns>
        IQueryable<T> All();

        /// <summary>
        /// Gets entity from repository by id.
        /// </summary>
        /// <param name="id">System identifier of entity in application.</param>
        /// <returns>Returns loaded entity or null.</returns>
        T GetById(long id);

        /// <summary>
        /// Saves entity in the repository.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        void InsertOrUpdate(T entity, bool startTrackProperties = false);

        /// <summary>
        /// Deletes entity from repository.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes entity by mathing id.
        /// </summary>
        /// <param name="id"></param>
        void Delete(long id);
    }
}