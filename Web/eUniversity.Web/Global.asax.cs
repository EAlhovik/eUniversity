using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace eUniversity.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IContainer container;

        protected void Application_Start()
        {

           BootstrapContainer();

            AreaRegistration.RegisterAllAreas();
            /*
             automapperConfigurator = DependencyResolver.Current.GetService<AutomapperConfigurator>();
            automapperConfigurator.Configure();
             */
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        private static void BootstrapContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).AsSelf();
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        protected void Application_End()
        {
            container.Dispose();
        }
    }
}