namespace WindowsServiceManager.Database.IntegrationTests
{
    using System;

    using NUnit.Framework;

    [SetUpFixture]
    public class Global
    {
        [SetUp]
        public static void AssemblyInitialize()
        {
            //Console.WriteLine(context);
            System.Data.Entity.Database.SetInitializer(new TestContextInitialiser());
        }
    }
}