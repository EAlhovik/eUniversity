using System.Collections.Generic;
using eUniversity.Business.ViewModels.Speciality;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for speciality management service
    /// </summary>
    public interface ISpecialityManagementService
    {
        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Speciality view model</returns>
        SpecialityViewModel Open(long? id);

        /// <summary>
        /// Saves the specified speciality.
        /// </summary>
        /// <param name="speciality">The speciality.</param>
        void Save(SpecialityViewModel speciality);

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <returns>All specialities</returns>
        IEnumerable<SpecialityRowViewModel> GetSpecialities();
    }
}