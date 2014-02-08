using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Business.ViewModels.Membership;
using eUniversity.Business.ViewModels.Speciality;
using eUniversity.Business.ViewModels.Specialization;
using eUniversity.Data.Entities;

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
                  .ForMember(vm => vm.UserName, opt => opt.MapFrom(m => m.UserName))
                  .ForMember(vm => vm.Created, opt => opt.MapFrom(m => m.Created.ToShortDateString()))
                  .ForMember(vm => vm.IsApproved, opt => opt.MapFrom(m => m.IsApproved))
                ;

            Mapper.CreateMap<RegisterViewModel, User>()
                  .ForMember(m => m.Id, opt => opt.Ignore())
                  .ForMember(m => m.UserName, opt => opt.MapFrom(vm => vm.UserName))
                  .ForMember(m => m.Password, opt => opt.MapFrom(vm => vm.Password))
                  .ForMember(m => m.IsApproved, opt => opt.UseValue(false))
                ;

            #endregion

            #region Speciality

            Mapper.CreateMap<Speciality, SpecialityRowViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                ;

            Mapper.CreateMap<Speciality, SpecialityViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                ;

            Mapper.CreateMap<SpecialityViewModel, Speciality>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
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
                ;

            Mapper.CreateMap<Specialization, SpecializationViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.Name, opt => opt.MapFrom(m => m.Name))
                .ForMember(vm => vm.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(vm => vm.SpecialityId, opt => opt.MapFrom(m => m.SpecialityId))
                ;

            Mapper.CreateMap<SpecializationViewModel, Specialization>()
                .ForMember(m => m.Id, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(vm => vm.Description))
                .ForMember(m => m.SpecialityId, opt => opt.MapFrom(vm => vm.SpecialityId.Value))
                ;

            Mapper.CreateMap<Specialization, SelectedItemViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id.ToString()))
                .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Name))
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
                .ForMember(vm => vm.Semesters, opt => opt.MapFrom(m => m.Semesters))
                ;

            Mapper.CreateMap<Curriculum, CurriculumHeaderViewModel>()
//                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(vm => vm.CountSemesters, opt => opt.MapFrom(m => universityProfileService.CreateCountSemesters(m.Semesters.Count)))
                .ForMember(vm => vm.DateOfEnactment, opt => opt.MapFrom(m => m.DateOfEnactment))
                .ForMember(vm => vm.Specialization, opt => opt.MapFrom(m => universityProfileService.CreateSpecialization(m.SpecializationId)))
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

            #endregion

            #region Subject

            Mapper.CreateMap<Subject, SubjectViewModel>()
                .ForMember(vm => vm.Subject, opt => opt.MapFrom(m => m))
                .ForMember(vm => vm.Assignee, opt => opt.MapFrom(m => universityProfileService.CreateAssignee(m)))
                ;

            Mapper.CreateMap<Subject, SelectedItemViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id.ToString()))
                .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Name))
                ;


            Mapper.CreateMap<SubjectViewModel, Subject>()
                  .ForMember(m => m.Id, opt => opt.Ignore())
                  .ForMember(m => m.Themes, opt => opt.Ignore())
                  .ForMember(m => m.Name, opt => opt.MapFrom(vm => vm.Subject.Text))
                ;

            #endregion
        }
    }
}