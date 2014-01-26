using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services.ManagementServices
{
    /// <summary>
    /// Represents curriculum management service
    /// </summary>
    public class CurriculumManagementService : ICurriculumManagementService
    {
        private readonly ISemesterManagementService semesterManagementService;
        private readonly ICurriculumService curriculumService;
        private readonly IEUniversityUow eUniversityUow;

        public CurriculumManagementService(ISemesterManagementService semesterManagementService,
            ICurriculumService curriculumService, IEUniversityUow eUniversityUow)
        {
            this.semesterManagementService = semesterManagementService;
            this.curriculumService = curriculumService;
            this.eUniversityUow = eUniversityUow;
        }

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

        private void UpdateModel(CurriculumViewModel viewModel, Curriculum curriculum)
        {
            curriculumService.Save(curriculum);
            Mapper.Map<CurriculumViewModel, Curriculum>(viewModel, curriculum);
        }

        #endregion
    }
}