using System.Collections.Generic;
using eUniversity.Business.ViewModels;

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
        IEnumerable<SelectedItemViewModel> GetSpecialities(string term);

        /// <summary>
        /// Gets the speciality.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SelectedItemViewModel GetSpeciality(long? id); //todo: remove

        /// <summary>
        /// Gets the specialization.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>Specializations by term</returns>
        IEnumerable<SelectedItemViewModel> GetSpecialization(string term);

        /// <summary>
        /// Gets the professors.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>Professors by term</returns>
        IEnumerable<SelectedItemViewModel> GetProfessors(string term);

        /// <summary>
        /// Gets the semesters.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>Semesters</returns>
        IEnumerable<SelectedItemViewModel> GetSemesters(string term);

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>List groups</returns>
        IEnumerable<SelectedItemViewModel> GetGroups(string term);
    }
}