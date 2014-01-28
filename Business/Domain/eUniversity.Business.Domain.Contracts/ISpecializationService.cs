using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for specializatoin service
    /// </summary>
    public interface ISpecializationService : IBaseService<Specialization>
    {
        SelectedItemModel GetSelectedItemById(long id);
    }
}