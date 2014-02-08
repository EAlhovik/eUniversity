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
//        private readonly ICurriculumService curriculumService;
//        private readonly IEUniversityUow eUniversityUow;

        public CurriculumManagementService(ISemesterManagementService semesterManagementService,
            ICurriculumService curriculumService, IEUniversityUow eUniversityUow):base(eUniversityUow,curriculumService)
        {
            this.semesterManagementService = semesterManagementService;
//            this.curriculumService = curriculumService;
//            this.eUniversityUow = eUniversityUow;
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
/*
        #region ICurriculumManagementService Members

        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CurriculumViewModel</returns>
        public CurriculumViewModel Open(long? id)
        {
            var curriculum = curriculumService.CreateOrOpen(id);
            var viewModel = Mapper.Map<Curriculum, CurriculumViewModel>(curriculum);
            viewModel.Semesters = viewModel.Semesters.OrderBy(s => s.Sequential);
            return viewModel;
        }

        /// <summary>
        /// Saves the specified curriculum.
        /// </summary>
        /// <param name="viewModel">The curriculum.</param>
        public void Save(CurriculumViewModel viewModel)
        {
            var curriculum = new Curriculum() { Id = viewModel.CurriculumHeader.Id };
            UpdateModel(viewModel, curriculum);

            semesterManagementService.Save(viewModel.Semesters, curriculum);

            eUniversityUow.Commit();
        }



        #endregion
   */
    }
}