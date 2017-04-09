using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Features.Variance;
using Autofac.Integration.WebApi;
using MediatR;
using OP.RememberTheDate.Configuration;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Commands;
using OP.RememberTheDate.WebService.Handlers;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            StorageFactory.Setup(RememberTheDateConfigurationContainer.Get().Common.DatabaseConnectionString);

            RegisterDependencies();
        }

        private static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            RegisterStorage(builder);
            RegisterServices(builder);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterStorage(ContainerBuilder builder)
        {
            builder.RegisterType<WriteStorage>().As<IWriteStorage<DateModel>>().InstancePerRequest();
            builder.RegisterType<ReadStorage>().As<IReadStorage<DateModel>>().InstancePerRequest();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsSelf().AsImplementedInterfaces();
            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            RegisterCommands(builder);
            RegisterQueries(builder);
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (RegisterDate).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (RegisterDateHandler).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }

        private static void RegisterQueries(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (DatesByNameQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (DatesByNameQueryHandler).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (DatesByMonthQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (DatesByMonthQueryHandler).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (DatesByYearQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (DatesByYearQueryHandler).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (DatesByRangeQuery).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof (DatesByRangeQueryHandler).GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
    }
}
