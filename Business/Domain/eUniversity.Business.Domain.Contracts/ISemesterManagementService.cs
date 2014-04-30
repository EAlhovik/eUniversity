using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interaface for semester management service
    /// </summary>
    public interface ISemesterManagementService
    {
        IEnumerable<SemesterViewModel> GetSemesters(long? curriculumId);

        void Save(IEnumerable<SemesterViewModel> semesters, Curriculum curriculum);
        IEnumerable<SemesterViewModel> CreateSemesters(int count);
    }
}