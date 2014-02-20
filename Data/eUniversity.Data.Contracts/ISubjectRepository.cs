using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Contracts
{
    /// <summary>
    /// Interface for subject repository
    /// </summary>
    public interface ISubjectRepository: IRepository<Subject>
    {
        IEnumerable<Subject> GetSubjects();
    }
}