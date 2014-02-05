using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for professor profile service
    /// </summary>
    public interface IProfessorProfileService : IBaseService<ProfessorProfile>
    {
        IEnumerable<SelectedItemModel> GetProfessors(string term);
    }
}