namespace WindowsServiceManager.IntegrationTests
{
    using Autofac;

    using NUnit.Framework;

    using WindowsServiceManager.WebGui.AutofacModules;
    using WindowsServiceManager.WebGui.Controllers;

    [TestFixture]
    public class AutofacModuleCheck
    {
        [Test]
        public void RootModule_Resolves_HomeController()
        {
            var container = PrepareContainerWithRootModuleRegistered;

            container.Resolve<HomeController>();
        }

        [Test]
        public void RootModule_Resolves_ServiceActionController()
        {
            var container = PrepareContainerWithRootModuleRegistered;

            container.Resolve<ServiceActionController>();
        }

        [Test]
        public void RootModule_Resolves_ServiceDetailController()
        {
            var container = PrepareContainerWithRootModuleRegistered;

            container.Resolve<ServiceDetailController>();
        }

        [Test]
        public void RootModule_Resolves_ServiceTaggingController()
        {
            var container = PrepareContainerWithRootModuleRegistered;

            container.Resolve<ServiceTaggingController>();
        }

        private static IContainer PrepareContainerWithRootModuleRegistered
        {
            get
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule<RootModule>();
                var container = builder.Build();
                return container;
            }
        }
    }
}
