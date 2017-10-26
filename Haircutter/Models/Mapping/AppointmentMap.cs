using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Haircutter.Models.Mapping
{
    public class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Appointments");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.customerId).HasColumnName("customerId");
            this.Property(t => t.appointmentDate).HasColumnName("appointmentDate");

            // Relationships
            this.HasOptional(t => t.Customer)
                .WithMany(t => t.Appointments)
                .HasForeignKey(d => d.customerId);

        }
    }
}
