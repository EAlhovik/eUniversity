using eUniversity.Business.ViewModels.Speciality;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for speciality management service
    /// </summary>
    public interface ISpecialityManagementService : IBaseManagementService<SpecialityViewModel, SpecialityRowViewModel>
    {
    }
}