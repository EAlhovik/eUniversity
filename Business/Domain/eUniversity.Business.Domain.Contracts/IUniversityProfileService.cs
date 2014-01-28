using eUniversity.Business.Helpers;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for university profile service
    /// </summary>
    public interface IUniversityProfileService
    {
        long GetId(SelectedItemModel selectedItemModel);

        SelectedItemModel CreateSpecialization(long id);
        SelectedItemModel CreateCountSemesters(int countSemesters);
    }
}