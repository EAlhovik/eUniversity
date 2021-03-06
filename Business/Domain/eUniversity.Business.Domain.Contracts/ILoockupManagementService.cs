﻿using System.Collections.Generic;
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
        IEnumerable<SelectedItemViewModel> GetSpecializations(string term);

        /// <summary>
        /// Gets the specialization.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        SelectedItemViewModel GetSpecialization(long? id);

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

        /// <summary>
        /// Gets the subjects.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>list</returns>
        IEnumerable<SelectedItemViewModel> GetSubjects(string term);

        /// <summary>
        /// Gets the subject.
        /// </summary>
        /// <param name="parseResult">The parse result.</param>
        /// <returns></returns>
        SelectedItemViewModel GetSubject(string parseResult);



        /// <summary>
        /// Gets the type of the subject.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Selected subject type by id</returns>
        SelectedItemViewModel GetSubjectType(string id);

        /// <summary>
        /// Gets the subject types.
        /// </summary>
        /// <returns></returns>
        IEnumerable<SelectedItemViewModel> GetSubjectTypes(bool isLast);

        /// <summary>
        /// Themeses the specified term.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>selected thems</returns>
        IEnumerable<SelectedItemViewModel> GetThemes(string term);

        /// <summary>
        /// Themeses the by ids.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>selected thems</returns>
        SelectedItemViewModel GetTheme(string id);

        /// <summary>
        /// Gets the theme description.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>theme description</returns>
        string GetThemeDescription(long id);
    }
}