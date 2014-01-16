using System.Collections.Generic;
using eUniversity.Business.ViewModels.Specialization;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for specialization management service
    /// </summary>
    public interface ISpecializationManagementService
    {
        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>specialization view model</returns>
        SpecializationViewModel Open(long? id);

        /// <summary>
        /// Saves the specified specialization.
        /// </summary>
        /// <param name="specialization">The specialization.</param>
        void Save(SpecializationViewModel specialization);

        /// <summary>
        /// Gets the specializations.
        /// </summary>
        /// <returns>all specializations</returns>
        IEnumerable<SpecializationRowViewModel> GetSpecializations();
    }
}