using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ManagementServices.Base;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents curriculum management service
    /// </summary>
    public class CurriculumManagementService : BaseManagementService<CurriculumViewModel, CurriculumViewModel, Curriculum>, ICurriculumManagementService
    {
        private readonly ISemesterManagementService semesterManagementService;

        public CurriculumManagementService(ISemesterManagementService semesterManagementService,
            ICurriculumService curriculumService, IEUniversityUow eUniversityUow):base(eUniversityUow,curriculumService)
        {
            this.semesterManagementService = semesterManagementService;
        }

        public override void Save(CurriculumViewModel viewModel)
        {
            var curriculum = new Curriculum() { Id = viewModel.Id };
            UpdateModel(viewModel, curriculum);

            semesterManagementService.Save(viewModel.Semesters, curriculum);

            UnitOfWork.Commit();
        }
        private void UpdateModel(CurriculumViewModel viewModel, Curriculum curriculum)
        {
            Service.Save(curriculum);
            Mapper.Map<CurriculumViewModel, Curriculum>(viewModel, curriculum);
        }
    }
}