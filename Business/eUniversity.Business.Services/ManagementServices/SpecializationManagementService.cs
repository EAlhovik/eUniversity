using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Specialization;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services.ManagementServices
{
    /// <summary>
    /// Represents specialization management service
    /// </summary>
    public class SpecializationManagementService : ISpecializationManagementService
    {
        private readonly ISpecializationService specializationService;
        private readonly IEUniversityUow unitOfWork;

        public SpecializationManagementService(ISpecializationService specializationService, IEUniversityUow unitOfWork)
        {
            this.specializationService = specializationService;
            this.unitOfWork = unitOfWork;
        }

        #region ISpecializationManagementService Members

        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns> Specialization view model </returns>
        public SpecializationViewModel Open(long? id)
        {
            var specialization = specializationService.CreateOrOpen(id);
            var viewModel = Mapper.Map<Specialization, SpecializationViewModel>(specialization);
            return viewModel;
        }

        public void Save(SpecializationViewModel viewModel)
        {
            var specialization = specializationService.CreateOrOpen(viewModel.Id);
            Mapper.Map<SpecializationViewModel, Specialization>(viewModel, specialization);
            specializationService.Save(specialization);
            unitOfWork.Commit();
        }

        /// <summary>
        /// Gets the specializations.
        /// </summary>
        /// <returns> all specializations </returns>
        public IEnumerable<SpecializationRowViewModel> GetSpecializations()
        {
            var list = specializationService.All().Select(Mapper.Map<Specialization,SpecializationRowViewModel>);
            return list;
        }

        #endregion
    }
}