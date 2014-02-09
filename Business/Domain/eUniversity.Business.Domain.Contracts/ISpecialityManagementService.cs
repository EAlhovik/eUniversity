using System.Collections.Generic;
using eUniversity.Business.ViewModels.Speciality;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for speciality management service
    /// </summary>
    public interface ISpecialityManagementService
    {
        SpecialityViewModel Open(long? id);
        void Save(SpecialityViewModel curriculum);

        IEnumerable<SpecialityRowViewModel> GetRows();
    }
}