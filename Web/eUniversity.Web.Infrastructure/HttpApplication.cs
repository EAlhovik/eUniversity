using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using eUniversity.Business.AutoMapper;
using eUniversity.Business.Domain.Contracts;

namespace eUniversity.Web.Infrastructure
{
    public abstract class HttpApplication : System.Web.HttpApplication
    {
        
        private static IContainer container;
        private AutomapperConfigurator automapperConfigurator;

        protected void Application_Start()
        {
            BootstrapContainer();
            automapperConfigurator = DependencyResolver.Current.GetService<AutomapperConfigurator>();
            automapperConfigurator.Configure();

            Register();
        }

        protected abstract void Register();

        protected void Application_End()
        {
            container.Dispose();
        }

        private void BootstrapContainer()
        {
            var builder = new ContainerBuilder();
            RegisterControllers(builder);

            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected abstract void RegisterControllers(ContainerBuilder builder);

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var serv = DependencyResolver.Current.GetService(typeof (IAuthorizationService));
            ((IAuthorizationService) serv).User = User;
        }

    }
}