namespace WindowsServiceManager.WebGui.AutofacModules
{
    using WindowsServiceManager.WebGui.Authorization;
    using WindowsServiceManager.WebGui.Controllers;

    using Autofac;
    using Autofac.Integration.Mvc;

    using WindowsServiceManager.Core;
    using WindowsServiceManager.Core.Domain;
    using WindowsServiceManager.Core.EnumerationConversions.ServiceStatus;
    using WindowsServiceManager.Database;
    using WindowsServiceManager.WebGui.Models;

    public class RootModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterType<HomeModel>().As<IHomeModel>();

            builder.RegisterType<ServiceActionModel>().As<IServiceActionModel>();

            builder.RegisterType<ServiceDetailModel>().As<IServiceDetailModel>();
            builder.RegisterType<ServiceTaggingModel>().As<IServiceTaggingModel>();
            builder.RegisterType<ServiceAccess>().As<IServiceAccess>();
            builder.RegisterType<ServiceStatusFactory>().As<IServiceStatusFactory>();
            builder.RegisterType<StatusConverter>().As<IServiceStatusApplier<StatusDisplayInfo>>();
            builder.RegisterType<ServiceTagContext>();
            builder.RegisterType<TagRepository>().As<ITagRepository>();
            builder.RegisterType<CachedTagRepository>().As<ICachedTagRepository>().SingleInstance();
            builder.RegisterType<RoleAuthorizationStrategy>().As<IAuthorizationStrategy>();
        }
    }
}
