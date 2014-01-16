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

        public LoockupManagementService(ISpecialityService specialityService)
        {
            this.specialityService = specialityService;
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

        #endregion

    }
}