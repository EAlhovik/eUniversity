using System.Collections.Generic;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Services.ManagementServices
{
    /// <summary>
    /// Represents semester management service
    /// </summary>
    public class SemesterManagementService : ISemesterManagementService
    {
        public IEnumerable<SemesterViewModel> GetSemesters(long? curriculumId)
        {
            if (!curriculumId.HasValue || curriculumId.Value == 0)
            {
                return Enumerable.Range(0, 8).Select(p => new SemesterViewModel());
            }
            return Enumerable.Empty<SemesterViewModel>();
        }
    }
}