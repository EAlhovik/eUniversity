using System.Collections.Generic;
using eUniversity.Business.ViewModels.Specialization;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for specialization management service
    /// </summary>
    public interface ISpecializationManagementService
    {
        SpecializationViewModel Open(long? id);
        void Save(SpecializationViewModel curriculum);

        IEnumerable<SpecializationRowViewModel> GetRows(); 
    }
}