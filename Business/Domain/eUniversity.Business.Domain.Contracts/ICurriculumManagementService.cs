using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for curriculum management service
    /// </summary>
    public interface ICurriculumManagementService : IBaseManagementService<CurriculumViewModel, CurriculumViewModel>
    {
    }
}