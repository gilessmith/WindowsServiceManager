namespace WindowsServiceManager.WebGui
{
    using System;
    using System.Configuration;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Autofac;
    using Autofac.Integration.Mvc;

    using WindowsServiceManager.WebGui.Authorization;
    using WindowsServiceManager.WebGui.AutofacModules;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var bundle = new ScriptBundle("~/bundles/scripts/app/js");
            bundle.IncludeDirectory("~/Scripts/app", "*.js", true);
            BundleTable.Bundles.Add(bundle);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            SetupDependencies();
        }

        private static void SetupDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RootModule>();
            var container = builder.Build();
            ConfigureAuthorization(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void ConfigureAuthorization(IContainer container)
        {
            var roleAuthorizationIsDisabled = ConfigurationManager.AppSettings["RoleAuthorizationDisabled"];

            // Only disable authorisation if the config is set and the value equals "true"
            if (roleAuthorizationIsDisabled != null && roleAuthorizationIsDisabled.Equals("true", StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            BaseWebConfigAuthorizeAttribute.AuthorizationStrategy = container.Resolve<IAuthorizationStrategy>();
        }
    }
}
