using AutoMapper.Internal;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Common.Utilities;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents university profile service
    /// </summary>
    public class UniversityProfileService : IUniversityProfileService
    {
        private readonly ISpecializationService specializationService;
        public UniversityProfileService(ISpecializationService specializationService)
        {
            this.specializationService = specializationService;
        }

        public long GetId(SelectedItemModel selectedItemModel)
        {
            if (selectedItemModel == null)
            {
                return 0;
            }
            long id;
            long.TryParse(selectedItemModel.Id, out id);
            return id;
        }

        public SelectedItemModel CreateSpecialization(long id)
        {
            return specializationService.GetSelectedItemById(id);
        }

        public SelectedItemModel CreateCountSemesters(int countSemesters)
        {
            return new SelectedItemModel
            {
                Id = countSemesters.ToString(),
                Text = EnumHelper.GetEnumDescription((SemesterEnum) countSemesters)
            };
        }
    }
}