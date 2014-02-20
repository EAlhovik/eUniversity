using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Business.ViewModels.Subject;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for subject management service
    /// </summary>
    public interface ISubjectManagementService
    {
        void Save(IEnumerable<SubjectViewModel> subjects, Semester semester);
        void Delete(IEnumerable<Subject> subjects);

        IEnumerable<SubjectRowViewModel> GetRows();
    }
}