using System.Collections.Generic;
using eUniversity.Business.Helpers;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for loockup management service
    /// </summary>
    public interface ILoockupManagementService
    {
        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>specialities by term</returns>
        IEnumerable<SelectedItemModel> GetSpecialities(string term);

        /// <summary>
        /// Gets the speciality.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SelectedItemModel GetSpeciality(long? id);
    }
}