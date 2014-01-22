using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for curriculum management service
    /// </summary>
    public interface IСurriculumManagementService
    {
        CurriculumViewModel Open(long? id);
    }
}