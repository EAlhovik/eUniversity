using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Services.ManagementServices
{
    /// <summary>
    /// Represents curriculum management service
    /// </summary>
    public class СurriculumManagementService : IСurriculumManagementService
    {
        private readonly ISemesterManagementService semesterManagementService;

        public СurriculumManagementService(ISemesterManagementService semesterManagementService)
        {
            this.semesterManagementService = semesterManagementService;
        }

        public CurriculumViewModel Open(long? id)
        {
            return new CurriculumViewModel
            {
                HeaderSection = OpenHeader(id),
                Semesters = semesterManagementService.GetSemesters(id)
            };
        }

        private HeaderSectionViewModel OpenHeader(long? id)
        {
            return new HeaderSectionViewModel
            {
                Id = id.GetValueOrDefault()
            };
        }
    }
}