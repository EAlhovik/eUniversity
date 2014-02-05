using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Common.Utilities;
using eUniversity.Data.Entities;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents management service
    /// </summary>
    public class LoockupManagementService : ILoockupManagementService
    {
        private readonly ISpecialityService specialityService;
        private readonly ISpecializationService specializationService;
        private readonly IProfessorProfileService professorProfileService;

        public LoockupManagementService(ISpecialityService specialityService, ISpecializationService specializationService, IProfessorProfileService professorProfileService)
        {
            this.specialityService = specialityService;
            this.specializationService = specializationService;
            this.professorProfileService = professorProfileService;
        }

        #region ILoockupManagementService Members

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns> specialities by term </returns>
        public IEnumerable<SelectedItemViewModel> GetSpecialities(string term)
        {
            var specialities =
                specialityService.All().Where(
                                     spec =>
                                     string.IsNullOrEmpty(term) || spec.Name.ToUpper().IndexOf(term.ToUpper()) >= 0);
            return specialities.Select(Mapper.Map<Speciality, SelectedItemViewModel>);
        }

        /// <summary>
        /// Gets the speciality.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SelectedItemViewModel GetSpeciality(long? id)//todl:remove
        {
            var speciality = specialityService.CreateOrOpen(id);
            return Mapper.Map<Speciality, SelectedItemViewModel>(speciality);
        }

        public IEnumerable<SelectedItemViewModel> GetSpecialization(string term)
        {
            var specializations =
                specializationService.All().Where(
                                     TermPredicate(term));
            return specializations.Select(Mapper.Map<Specialization, SelectedItemViewModel>);
        }

        public IEnumerable<SelectedItemViewModel> GetProfessors(string term)
        {
            return professorProfileService.GetProfessors(term).Select(Mapper.Map<SelectedItemModel, SelectedItemViewModel>);
        }

        public IEnumerable<SelectedItemViewModel> GetSemesters(string term)
        {
            var values = EnumHelper.GetEnumValues(typeof(SemesterEnum)).Select(p => new SelectedItemViewModel { Id = p.Key, Text = p.Value });
            return string.IsNullOrEmpty(term) ? values : values.Where(s => s.Text.Contains(term));
        }

        #endregion


        private static Func<Specialization, bool> TermPredicate(string term)
        {
            return spec =>
                string.IsNullOrEmpty(term) || spec.Name.ToUpper().IndexOf(term.ToUpper()) >= 0;
        }
    }
}