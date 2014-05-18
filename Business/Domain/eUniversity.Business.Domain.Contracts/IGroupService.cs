using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for group servise
    /// </summary>
    public interface IGroupService : IBaseService<Group>
    {
        IEnumerable<long> GetGroupStudents(long id);
    }
}