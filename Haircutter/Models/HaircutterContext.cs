using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Haircutter.Models.Mapping;

namespace Haircutter.Models
{
    public partial class HaircutterContext : DbContext
    {
        static HaircutterContext()
        {
            Database.SetInitializer<HaircutterContext>(null);
        }

        public HaircutterContext()
            : base("Name=HaircutterContext")
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AppointmentMap());
            modelBuilder.Configurations.Add(new CustomerMap());
        }
    }
}
