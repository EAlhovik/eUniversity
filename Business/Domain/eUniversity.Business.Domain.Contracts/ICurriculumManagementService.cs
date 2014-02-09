using System.Collections.Generic;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for curriculum management service
    /// </summary>
    public interface ICurriculumManagementService
    {
        CurriculumViewModel Open(long? id);
        void Save(CurriculumViewModel curriculum);

        IEnumerable<CurriculumViewModel> GetRows();
    }
}