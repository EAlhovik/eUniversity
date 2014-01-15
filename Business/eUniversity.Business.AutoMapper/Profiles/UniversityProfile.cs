using AutoMapper;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Auth;
using eUniversity.Business.ViewModels.Speciality;

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
        }
    }
}