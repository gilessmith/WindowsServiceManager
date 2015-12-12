namespace WindowsServiceManager.Database
{
    using System.Data.Entity.ModelConfiguration;

    using WindowsServiceManager.Core;

    public class ServiceTagConfiguration : EntityTypeConfiguration<ServiceTag>
    {
        public ServiceTagConfiguration()
        {
            this.ToTable("ServiceTags");

            this.HasKey(s => s.RowId);
            
            this.Property(p => p.ServiceId)
                .HasMaxLength(400)
                .IsRequired();

            this.Property(p => p.TagText)
                .HasMaxLength(400)
                .IsRequired();
        }
    }
}