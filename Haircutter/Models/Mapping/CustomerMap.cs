using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Haircutter.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.firstName)
                .HasMaxLength(50);

            this.Property(t => t.lastName)
                .HasMaxLength(50);

            this.Property(t => t.color)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Customers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.color).HasColumnName("color");
            this.Property(t => t.isSub).HasColumnName("isSub");
            this.Property(t => t.appointmentsCount).HasColumnName("appointmentsCount");
        }
    }
}
