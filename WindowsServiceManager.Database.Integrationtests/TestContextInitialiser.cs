namespace WindowsServiceManager.Database.IntegrationTests
{
    public class TestContextInitialiser : System.Data.Entity.DropCreateDatabaseAlways<ServiceTagContext>
    {
        protected override void Seed(ServiceTagContext context)
        {
            context.SaveChanges();
        }
    }
}