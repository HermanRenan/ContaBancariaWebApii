using Autofac;
using Autofac.Integration.WebApi;
using LayerDataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoBanco.App_Start
{
    public class AutofacWebapi
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            var assembly = Assembly.GetExecutingAssembly();

            Assembly[] assemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("Layer")).ToArray();

            //Register your Web API controllers.  
            builder.RegisterApiControllers(assembly);

            //builder.RegisterAssemblyTypes(typeof(RmService).Assembly)
            //  .Where(t => t.Name.EndsWith("Service"))
            //  .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(TbOrgStructureService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(typeof(RmRepository).Assembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();


            //builder.RegisterAssemblyTypes(typeof(RmRepository).Assembly)
            //    .AsClosedTypesOf(typeof(IBaseRepository<>))
            //    .InstancePerLifetimeScope();



            //builder.RegisterAssemblyTypes(typeof(RmService).Assembly)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces().InstancePerRequest();

            //builder.RegisterAssemblyTypes(typeof(RmRepository).Assembly)
            //    .Where(t => t.Name.EndsWith("Repository"))
            //    .AsImplementedInterfaces().InstancePerRequest();


            //builder.RegisterAssemblyTypes(typeof(RmRepository).Assembly)
            //    .AsClosedTypesOf(typeof(IBaseRepository<>))
            //    .AsImplementedInterfaces().InstancePerRequest();


            builder.RegisterAssemblyTypes(assemblies)
                .AsImplementedInterfaces().InstancePerLifetimeScope()
                .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            builder.RegisterAssemblyTypes(assemblies)
                .AsClosedTypesOf(typeof(IBaseRepository<>)).AsImplementedInterfaces();

            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}
