using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;

namespace eUniversity.Business.Services.ManagementServices
{
    /// <summary>
    /// Represents management service
    /// </summary>
    public class LoockupManagementService : ILoockupManagementService
    {
        private readonly ISpecialityService specialityService;
        private readonly ISpecializationService specializationService;

        public LoockupManagementService(ISpecialityService specialityService, ISpecializationService specializationService)
        {
            this.specialityService = specialityService;
            this.specializationService = specializationService;
        }

        #region ILoockupManagementService Members

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns> specialities by term </returns>
        public IEnumerable<SelectedItemModel> GetSpecialities(string term)
        {
            var specialities =
                specialityService.All().Where(
                                     spec =>
                                     string.IsNullOrEmpty(term) || spec.Name.ToUpper().IndexOf(term.ToUpper()) >= 0);
            return specialities.Select(Mapper.Map<Speciality, SelectedItemModel>);
        }

        /// <summary>
        /// Gets the speciality.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SelectedItemModel GetSpeciality(long? id)//todl:remove
        {
            var speciality = specialityService.CreateOrOpen(id);
            return Mapper.Map<Speciality, SelectedItemModel>(speciality);
        }

        public IEnumerable<SelectedItemModel> GetSpecialization(string term)
        {
            var specializations =
                specializationService.All().Where(
                                     TermPredicate(term));
            return specializations.Select(Mapper.Map<Specialization, SelectedItemModel>);
        }

        private static Func<Specialization, bool> TermPredicate(string term)
        {
            return spec =>
                string.IsNullOrEmpty(term) || spec.Name.ToUpper().IndexOf(term.ToUpper()) >= 0;
        }

        #endregion

    }
}