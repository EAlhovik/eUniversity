using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Enums;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Common.Utilities;
using eUniversity.Data.Entities;

namespace eUniversity.Business.ManagementServices.AutoMapperServices
{
    /// <summary>
    /// Represents university profile service
    /// </summary>
    public class UniversityProfileManagementService : IUniversityProfileManagementService
    {
        private readonly ISpecializationService specializationService;

        public UniversityProfileManagementService(ISpecializationService specializationService)
        {
            this.specializationService = specializationService;
        }

        public long GetId(SelectedItemViewModel selectedItemModel)
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
                Text = EnumHelper.GetEnumDescription((SemesterEnum)countSemesters)
            };
        }

        public SelectedItemModel CreateAssignee(Subject subject)
        {
            return new SelectedItemModel()
                {
                    Id = "0",
                    Text = "asdas"
                };
        }

        public string CreateSubjectType(SubjectTypeEnum subjectType)
        {
            return EnumHelper.GetEnumDescription(subjectType);
        }
    }
}