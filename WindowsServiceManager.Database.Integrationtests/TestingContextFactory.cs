namespace WindowsServiceManager.Database.IntegrationTests
{
    public class TestingContextFactory
    {
        private bool isInitialised = false;

        public ServiceTagContext CreateContext()
        {
            var context = new ServiceTagContext();
            if (!this.isInitialised)
            {
                context.Database.Initialize(true);
                this.isInitialised = true;
            }

            return context;
        }
    }
}