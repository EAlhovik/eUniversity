using System.Collections.Generic;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interaface for semester management service
    /// </summary>
    public interface ISemesterManagementService
    {
        IEnumerable<SemesterViewModel> GetSemesters(long? curriculumId);
    }
}