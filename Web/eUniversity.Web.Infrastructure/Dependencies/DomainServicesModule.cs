using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using eUniversity.Business.AutoMapper;
using eUniversity.Business.AutoMapper.Profiles;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ManagementServices;
using eUniversity.Business.Services.Auth;
using eUniversity.Business.Services.Base;

namespace eUniversity.Web.Infrastructure.Dependencies
{
    public class DomainServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(CurriculumManagementService).Assembly)
                .Where(t => t.Name.EndsWith("ManagementService")).AsImplementedInterfaces();

            builder.RegisterType(typeof(UniversityProfile)).AsImplementedInterfaces().As(typeof(Profile)).InstancePerHttpRequest();
            builder.RegisterType(typeof(AutomapperConfigurator)).AsSelf().InstancePerHttpRequest();

            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>().InstancePerHttpRequest();

//            builder.RegisterGeneric(typeof (BaseService<>)).OnActivated(e => e.Context.Resolve<IAuthorizationService>());
            builder.RegisterGeneric(typeof (BaseService<>)).PropertiesAutowired();
           
//            builder.RegisterType(customType).WithProperty("PropertyName", "value");

            //        //builder.RegisterType(typeof(FormsAuthProvider)).AsImplementedInterfaces();

            //        //builder.RegisterType(typeof(UniversityProfile)).AsImplementedInterfaces().As(typeof(AutoMapper.Profile)).InstancePerHttpRequest();
            //        //builder.RegisterType(typeof(AutomapperConfigurator)).AsSelf().InstancePerHttpRequest();

            //        base.Load(builder);
        }
    }
}