namespace WindowsServiceManager.Database
{
    using System.Data.Entity;

    using WindowsServiceManager.Core;

    public class ServiceTagContext : DbContext
    {
        public ServiceTagContext() : base("ServiceTagContext")
        {
        }

        public DbSet<ServiceTag> ServiceTags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ServiceTagConfiguration());
        }
    }
}