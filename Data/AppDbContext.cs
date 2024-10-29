using Microsoft.EntityFrameworkCore;
using AppointmentManagement.Models;

namespace AppointmentManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<Unavailability> Unavailabilities { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
    }
}