using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for speciality service
    /// </summary>
    public interface ISpecialityService
    {
        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of entity.</param>
        /// <returns>The Speciality entity. Null if entity doesn't exist</returns>
        Speciality CreateOrOpen(long? id);

        /// <summary>
        /// Saves the specified speciality.
        /// </summary>
        /// <param name="speciality">The speciality.</param>
        void Save(Speciality speciality);

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>All specialities</returns>
        IEnumerable<Speciality> All();
    }
}