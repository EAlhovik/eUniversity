using Autofac;
using Autofac.Integration.Mvc;
using eUniversity.Data;
using eUniversity.Data.Contracts;
using eUniversity.Data.Repositories;

namespace eUniversity.Web.Dependencies
{
    /// <summary>
    /// Represents module to register data access types
    /// </summary>
    public class DataAccessModule : Module
    {
         protected override void Load(ContainerBuilder builder)
         {
             builder.RegisterType<EUniversityDbContext>().AsSelf().WithParameter("connectionStringName",
                                                                           "eUniversityConnection").
                                                                           InstancePerHttpRequest();

             builder.RegisterAssemblyTypes(typeof(EUniversityUow).Assembly).Where(t => t.Name.EndsWith("Uow")).
                AsImplementedInterfaces();

             builder.RegisterGeneric(typeof(EFRepository<>))
                .As(typeof(IRepository<>));

         }
    }
}