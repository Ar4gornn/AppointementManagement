using Microsoft.EntityFrameworkCore;
using AppointmentManagement.Models;

namespace AppointmentManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets for each model/entity in your database
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Unavailability> Unavailabilities { get; set; }
        public DbSet<Availability> Availabilities { get; set; }

        // You can override OnModelCreating to further customize your database mappings if needed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}