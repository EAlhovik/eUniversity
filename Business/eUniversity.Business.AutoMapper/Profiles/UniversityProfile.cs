using AutoMapper;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Auth;

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
        }
    }
}