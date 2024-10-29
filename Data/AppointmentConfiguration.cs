using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentManagement.Data
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            // Configure table name, relationships, etc.
            builder.ToTable("Appointments");

            // For example, you could add a constraint that StartAt must be before EndAt
            builder.Property(a => a.StartAt)
                .IsRequired();

            builder.Property(a => a.EndAt)
                .IsRequired();
        }
    }
}