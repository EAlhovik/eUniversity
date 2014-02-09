﻿using eUniversity.Business.Domain.Contracts;
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
        private readonly ISpecialityService specialityService;
        public UniversityProfileManagementService(ISpecializationService specializationService, ISpecialityService specialityService)
        {
            this.specializationService = specializationService;
            this.specialityService = specialityService;
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

        public SelectedItemModel CreateSpeciality(long specialityId)
        {
            return specialityService.GetSelectedItemById(specialityId);
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
    }
}