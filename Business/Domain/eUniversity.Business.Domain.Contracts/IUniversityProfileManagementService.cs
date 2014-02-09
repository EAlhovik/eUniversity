using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for university profile service
    /// </summary>
    public interface IUniversityProfileManagementService
    {
        long GetId(SelectedItemViewModel selectedItemModel);

        SelectedItemModel CreateSpecialization(long id);
        SelectedItemModel CreateCountSemesters(int countSemesters);

        SelectedItemModel CreateAssignee(Subject subject);
        SelectedItemModel CreateSpeciality(long specialityId);
    }
}