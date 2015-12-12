using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using WindowsServiceManager.WebGui.AutofacModules;
    using WindowsServiceManager.WebGui.Controllers;

    using Autofac;

    using NUnit.Framework;

    class Program
    {
        static void Main(string[] args)
        {
            var t = new AutofacModuleCheck();
            t.CheckHomeControllerCanBeResolved();
        }
    }

    [TestFixture]
    public class AutofacModuleCheck
    {
        [Test]
        public void CheckHomeControllerCanBeResolved()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<RootModule>();
            var container = builder.Build();
            container.Resolve<HomeController>();
        }
    }
}
