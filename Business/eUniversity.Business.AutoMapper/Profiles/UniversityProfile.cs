using AutoMapper;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Business.ViewModels.Speciality;
using eUniversity.Business.ViewModels.Specialization;

namespace eUniversity.Business.AutoMapper.Profiles
{
    /// <summary>
    /// The profile for automapper configuration
    /// </summary>
    public class UniversityProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<RegisterViewModel, User>()
               .ForMember(m => m.Id, opt => opt.Ignore())
               .ForMember(m => m.UserName, opt => opt.MapFrom(vm => vm.UserName))
               .ForMember(m => m.Password, opt => opt.MapFrom(vm => vm.Password))
               ;

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

            Mapper.CreateMap<Speciality, SelectedItemModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id.ToString()))
                .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Name))
                ;

            #endregion

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

            Mapper.CreateMap<Specialization, SelectedItemModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(m => m.Id.ToString()))
                .ForMember(vm => vm.Text, opt => opt.MapFrom(m => m.Name))
                ;

        }
    }
}