using System;
using System.Linq;
using System.Threading.Tasks;
using AppointmentManagement.Models;

namespace AppointmentManagement.Data
{
    public static class DataSeeder
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (!context.Appointments.Any())
            {
                context.Appointments.Add(new Appointment
                {
                    Id = Guid.NewGuid(),
                    PatientName = "John Doe",
                    PatientPhone = "1234567890",
                    PatientId = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    Type = "General Checkup",
                    StartAt = new DateTime(2023, 12, 1, 9, 0, 0, DateTimeKind.Utc), // Valid and UTC Kind
                    EndAt = new DateTime(2023, 12, 1, 10, 0, 0, DateTimeKind.Utc),  // Valid and UTC Kind
                    Notes = "First appointment",
                    Status = 1,
                    BookingChannel = "Online",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                });

                await context.SaveChangesAsync();
            }

            if (!context.AppointmentTypes.Any())
            {
                context.AppointmentTypes.Add(new AppointmentType
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    Name = "General Checkup",
                    CreatedAt = DateTime.UtcNow
                });

                context.AppointmentTypes.Add(new AppointmentType
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    Name = "Specialist Consultation",
                    CreatedAt = DateTime.UtcNow
                });

                await context.SaveChangesAsync();
            }

            if (!context.Availabilities.Any())
            {
                context.Availabilities.Add(new Availability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    DayOfWeek = 1, // Monday
                    StartTime = new DateTime(2023, 12, 1, 9, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2023, 12, 1, 17, 0, 0, DateTimeKind.Utc),
                    CreatedAt = DateTime.UtcNow
                });

                context.Availabilities.Add(new Availability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    DayOfWeek = 2, // Tuesday
                    StartTime = new DateTime(2023, 12, 2, 9, 0, 0, DateTimeKind.Utc),
                    EndTime = new DateTime(2023, 12, 2, 17, 0, 0, DateTimeKind.Utc),
                    CreatedAt = DateTime.UtcNow
                });

                await context.SaveChangesAsync();
            }

            if (!context.Clinics.Any())
            {
                context.Clinics.Add(new Clinic
                {
                    Id = Guid.NewGuid(),
                    Name = "Health Clinic",
                    Title = "General Health Clinic",
                    PictureUrl = "http://example.com/clinic.jpg",
                    Specialty = "General Medicine",
                    Address = "123 Main St",
                    DetailedAddress = "Suite 100",
                    MapUrl = "http://example.com/map",
                    AllowNewPatientBooking = true,
                    AllowPatientBooking = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                context.Clinics.Add(new Clinic
                {
                    Id = Guid.NewGuid(),
                    Name = "Specialist Clinic",
                    Title = "Specialist Health Clinic",
                    PictureUrl = "http://example.com/specialist.jpg",
                    Specialty = "Cardiology",
                    Address = "456 Elm St",
                    DetailedAddress = "Suite 200",
                    MapUrl = "http://example.com/map2",
                    AllowNewPatientBooking = true,
                    AllowPatientBooking = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });

                await context.SaveChangesAsync();
            }

            if (!context.Unavailabilities.Any())
            {
                context.Unavailabilities.Add(new Unavailability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    Date = new DateTime(2023, 12, 25, 0, 0, 0, DateTimeKind.Utc), // Christmas
                    StartTime = new TimeSpan(0, 0, 0),
                    EndTime = new TimeSpan(23, 59, 59),
                    IsAllDay = true,
                    CreatedAt = DateTime.UtcNow
                });

                context.Unavailabilities.Add(new Unavailability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    Date = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), // New Year's Day
                    StartTime = new TimeSpan(0, 0, 0),
                    EndTime = new TimeSpan(23, 59, 59),
                    IsAllDay = true,
                    CreatedAt = DateTime.UtcNow
                });

                await context.SaveChangesAsync();
            }
        }
    }
}