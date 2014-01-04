﻿using Autofac;
using eUniversity.Business.Services.Auth;

namespace eUniversity.Web.Dependencies
{
    public class DomainServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            
    //        //builder.RegisterType(typeof(FormsAuthProvider)).AsImplementedInterfaces();

    //        //builder.RegisterType(typeof(UniversityProfile)).AsImplementedInterfaces().As(typeof(AutoMapper.Profile)).InstancePerHttpRequest();
    //        //builder.RegisterType(typeof(AutomapperConfigurator)).AsSelf().InstancePerHttpRequest();

    //        base.Load(builder);
        }
    }
}