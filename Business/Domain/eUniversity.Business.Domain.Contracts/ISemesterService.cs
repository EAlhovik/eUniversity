using System.Collections;
using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for semester service
    /// </summary>
    public interface ISemesterService : IBaseService<Semester>
    {
        void Save(IEnumerable<Semester> semesters);
        void Save(IEnumerable<SemesterViewModel> semesters);
    }
}