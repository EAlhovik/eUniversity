using System;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Enums;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Business.ViewModels.Dashboard;
using eUniversity.Business.ViewModels.Group;
using eUniversity.Business.ViewModels.Membership;
using eUniversity.Business.ViewModels.Speciality;
using eUniversity.Business.ViewModels.Specialization;
using eUniversity.Business.ViewModels.Subject;
using eUniversity.Business.ViewModels.Theme;
using eUniversity.Data.Entities;
using SemesterViewModel = eUniversity.Business.ViewModels.Curriculum.SemesterViewModel;

namespace eUniversity.Business.AutoMapper.Profiles
{
    /// <summary>
    /// The profile for automapper configuration
    /// </summary>
    public class UniversityProfile : Profile
    {
        private readonly IUniversityProfileManagementService universityProfileService;
        public UniversityProfile(IUniversityProfileManagementService universityProfileService)
        {
            this.universityProfileService = universityProfileService;
        }

        protected override void Configure()
        {
            #region SelectedItem

            Mapper.CreateMap<SelectedItemModel, SelectedItemViewModel>()
               .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
               .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Text))
                ;

            Mapper.CreateMap<SelectedItemViewModel, SelectedItemModel>()
               .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
               .ForMember(m => m.Text, opt => opt.MapFrom(vm => vm.Text))
                ;

            #endregion

            #region User

            Mapper.CreateMap<User, UserRowViewModel>()
                  .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                  .ForMember(vm => vm.Email, opt => opt.MapFrom(m => m.Email))
                  .ForMember(vm => vm.Created, opt => opt.MapFrom(m => m.Created.ToShortDateString()))
                  .ForMember(vm => vm.IsApproved, opt => opt.MapFrom(m => m.IsApproved))
                ;

            Mapper.CreateMap<RegisterViewModel, User>()
                  .ForMember(m => m.Id, opt => opt.Ignore())
                  .ForMember(m => m.Email, opt => opt.MapFrom(vm => vm.Email))
                  .ForMember(m => m.Password, opt => opt.MapFrom(vm => vm.Password))
                  .ForMember(m => m.IsApproved, opt => opt.UseValue(false))
                ;

            #endregion

            #region Profile

            Mapper.CreateMap<ProfileViewModel, StudentProfile>()
                .ForMember(m => m.Id, opt => opt.Ignore())
                .ForMember(m => m.FirstName, opt => opt.MapFrom(vm => vm.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(vm => vm.LastName))
                .ForMember(m => m.DateOfAdmission, opt => opt.MapFrom(vm => DateTime.Now))
                .ForMember(m => m.Group, opt => opt.Ignore())
                .ForMember(m => m.MiddleName, opt => opt.Ignore())
                ;


            Mapper.CreateMap<Curriculum, StudentDashboardViewModel>()
                .ForMember(vm => vm.Semesters, opt => opt.MapFrom(m => m.Semesters.OrderBy(s => s.Sequential)))
                .ForMember(vm => vm.DateOfEnactment, opt => opt.MapFrom(m => m.DateOfEnactment))
                ;


            Mapper.CreateMap<Semester, ViewModels.Dashboard.SemesterViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Sequential, opt => opt.MapFrom(m => m.Sequential))
                .ForMember(vm => vm.Subjects, opt => opt.MapFrom(m => m.Subjects))
                ;

            #endregion


            #region Speciality

            Mapper.CreateMap<Speciality, SpecialityRowViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(vm => vm.Status, opt => opt.MapFrom(m => m.Status))
                .ForMember(vm => vm.LastModified, opt => opt.MapFrom(m => universityProfileService.CreateDateDisplay(m.LastModified ?? m.Created)))
                ;

            Mapper.CreateMap<SpecialityRowViewModel, Speciality>()
                  .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                  .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Name))
                  .ForMember(m => m.Status, opt => opt.Ignore())
                  .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
                  .ForMember(m => m.LastModified, opt => opt.Ignore())
                ;

            Mapper.CreateMap<Speciality, SelectedItemViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id.ToString()))
                .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Name))
                ;

            #endregion

            #region Specialization

            Mapper.CreateMap<Specialization, SpecializationRowViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(vm => vm.Status, opt => opt.MapFrom(m => m.Status))
                .ForMember(vm => vm.LastModified, opt => opt.MapFrom(m => universityProfileService.CreateDateDisplay(m.LastModified ?? m.Created)))
                .ForMember(vm => vm.SpecialityId, opt => opt.MapFrom(m => m.SpecialityId.HasValue ? m.SpecialityId.Value : 0))
                ;

            Mapper.CreateMap<SpecializationRowViewModel, Specialization>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
                .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
                .ForMember(m => m.LastModified, opt => opt.Ignore())
                .ForMember(m => m.Status, opt => opt.Ignore())
                .ForMember(m => m.SpecialityId, opt => opt.MapFrom(vm => string.IsNullOrEmpty(vm.SpecialityId) ? (long?)null : long.Parse(vm.SpecialityId)))
                ;

            Mapper.CreateMap<Specialization, SelectedItemViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id.ToString()))
                .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Name))
                ;

            #endregion

            #region Group

            Mapper.CreateMap<Group, GroupRowViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(vm => vm.Status, opt => opt.MapFrom(m => m.Status))
                .ForMember(vm => vm.SpecializationId, opt => opt.MapFrom(m => m.SpecializationId.HasValue ? m.SpecializationId.Value : 0))
                .ForMember(vm => vm.LastModified, opt => opt.MapFrom(m => universityProfileService.CreateDateDisplay(m.LastModified ?? m.Created)))
                .ForMember(vm => vm.DateOfAdmission, opt => opt.MapFrom(m => m.DateOfAdmission))
                ;

            Mapper.CreateMap<GroupRowViewModel, Group>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
                .ForMember(m => m.DateOfAdmission, opt => opt.MapFrom(vm => vm.DateOfAdmission))
                .ForMember(m => m.LastModified, opt => opt.Ignore())
                .ForMember(m => m.Status, opt => opt.Ignore())
                .ForMember(m => m.SpecializationId, opt => opt.MapFrom(vm => string.IsNullOrEmpty(vm.SpecializationId) ? (long?)null : long.Parse(vm.SpecializationId)))
                ;

            #endregion

            #region Curriculum

            Mapper.CreateMap<CurriculumViewModel, Curriculum>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(m => m.DateOfEnactment, opt => opt.MapFrom(vm => vm.CurriculumHeader.DateOfEnactment))
                .ForMember(m => m.SpecializationId, opt => opt.MapFrom(vm => universityProfileService.GetId(vm.CurriculumHeader.Specialization)))
                .ForMember(m => m.Semesters, opt => opt.Ignore())
                ;

            Mapper.CreateMap<Curriculum, CurriculumViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.CurriculumHeader, opt => opt.MapFrom(m => m))
                .ForMember(vm => vm.Semesters, opt => opt.MapFrom(m => m.Semesters.OrderBy(s => s.Sequential)))
                ;

            Mapper.CreateMap<Curriculum, CurriculumHeaderViewModel>()
                .ForMember(vm => vm.CountSemesters, opt => opt.MapFrom(m => universityProfileService.CreateCountSemesters(m.Semesters.Count)))
                .ForMember(vm => vm.DateOfEnactment, opt => opt.MapFrom(m => m.DateOfEnactment))
                .ForMember(vm => vm.Specialization, opt => opt.MapFrom(m => universityProfileService.CreateSpecialization(m.SpecializationId)))
                ;

            Mapper.CreateMap<Curriculum, CurriculumRowViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.DateOfEnactment, opt => opt.MapFrom(m => m.DateOfEnactment.ToShortDateString()))
                .ForMember(vm => vm.LastModified, opt => opt.MapFrom(m => universityProfileService.CreateDateDisplay(m.LastModified ?? m.Created)))
                .ForMember(vm => vm.SpecializatoinName, opt => opt.MapFrom(m => universityProfileService.CreateSpecialization(m.SpecializationId).Text))
                ;

            #endregion

            #region Semester

            Mapper.CreateMap<SemesterViewModel, Semester>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(m => m.Sequential, opt => opt.MapFrom(vm => vm.Sequential))
                .ForMember(m => m.Subjects, opt => opt.Ignore())
                ;

            Mapper.CreateMap<Semester, SemesterViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Sequential, opt => opt.MapFrom(m => m.Sequential))
                .ForMember(vm => vm.Subjects, opt => opt.MapFrom(m => m.Subjects))
                ;

            Mapper.CreateMap<Subject, eUniversity.Business.ViewModels.Dashboard.SubjectViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.SubjectType, opt => opt.MapFrom(m => universityProfileService.CreateSubjectType(m.SubjectType)))
                .ForMember(vm => vm.Assignee, opt => opt.MapFrom(m => universityProfileService.CreateAssignee(m)))
                ;

            #endregion

            #region Subject

            Mapper.CreateMap<Subject, Subject>();

            Mapper.CreateMap<SubjectRowViewModel, Subject>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.SubjectName))
                .ForMember(m => m.Themes, opt => opt.MapFrom(vm => vm.Themes))
                ;
            Mapper.CreateMap<Subject, SubjectRowViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.SubjectName, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.SemesterNumber, opt => opt.MapFrom(m => m.Semester.Sequential.ToString()))
                .ForMember(vm => vm.CurriculumName, opt => opt.MapFrom(m => m.Semester.Curriculum.DateOfEnactment.ToShortDateString()))
                .ForMember(vm => vm.SpecializationName, opt => opt.MapFrom(m => universityProfileService.CreateSpecialization(m.Semester.Curriculum.SpecializationId).Text))
                ;

            Mapper.CreateMap<Subject, eUniversity.Business.ViewModels.Curriculum.SubjectViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.SubjectType, opt => opt.MapFrom(m => (int)m.SubjectType))
                .ForMember(vm => vm.Assignee, opt => opt.MapFrom(m => universityProfileService.CreateAssignee(m)))
                //                .ForMember(vm => vm.SubjectType, opt => opt.Ignore())
                ;

            Mapper.CreateMap<eUniversity.Business.ViewModels.Curriculum.SubjectViewModel, Subject>()
                  .ForMember(m => m.Id, opt => opt.Ignore())
                  .ForMember(m => m.Themes, opt => opt.Ignore())
                  .ForMember(m => m.Name, opt => opt.Ignore())
                  .ForMember(m => m.SubjectType, opt => opt.MapFrom(vm => (SubjectTypeEnum)int.Parse(vm.SubjectType)))
                ;

            #endregion

            #region Theme

            Mapper.CreateMap<Theme, ThemeRowViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.LastModified, opt => opt.MapFrom(m => universityProfileService.CreateDateDisplay(m.LastModified ?? m.Created)))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                ;

            Mapper.CreateMap<ThemeRowViewModel, Theme>()
                  .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                  .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(m => m.LastModified, opt => opt.Ignore())
                  .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
                ;

            Mapper.CreateMap<Theme, ThemeViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                ;

            Mapper.CreateMap<ThemeViewModel, Theme>()
                  .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                  .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Name))
                  .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
                ;

            //            Mapper.CreateMap<Speciality, SelectedItemViewModel>() todo: check if need
            //                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id.ToString()))
            //                .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Name))
            //                ;

            #endregion

        }
    }
}