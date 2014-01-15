using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Speciality;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services.ManagementServices
{
    /// <summary>
    /// Represents speciality management serivce
    /// </summary>
    public class SpecialityManagementService : ISpecialityManagementService
    {
        private readonly ISpecialityService specialityService;
        private readonly IEUniversityUow unitOfWork;

        public SpecialityManagementService(ISpecialityService specialityService, IEUniversityUow unitOfWork)
        {
            this.specialityService = specialityService;
            this.unitOfWork = unitOfWork;
        }

        #region ISpecialityManagementService Members

        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Speciality view model.</returns>
        public SpecialityViewModel Open(long? id)
        {
            var speciality = specialityService.CreateOrOpen(id);
            var viewModel = Mapper.Map<Speciality, SpecialityViewModel>(speciality);
            return viewModel;
        }

        public void Save(SpecialityViewModel specialitViewModely)
        {
            var speciality = specialityService.CreateOrOpen(specialitViewModely.Id);
            Mapper.Map<SpecialityViewModel, Speciality>(specialitViewModely, speciality);
            specialityService.Save(speciality);
            unitOfWork.Commit();
        }

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <returns> All specialities </returns>
        public IEnumerable<SpecialityRowViewModel> GetSpecialities()
        {
            var listViewModels = Mapper.Map<IEnumerable<Speciality>, IEnumerable<SpecialityRowViewModel>>(specialityService.All().ToList());
            return listViewModels;
        }

        #endregion

    }
}