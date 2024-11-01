using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Data;

public class DataSeeder
{
    public static async Task SeedData(AppDbContext context)
    {
        if (!await context.Clinics.AnyAsync())
        {
            await context.Clinics.AddRangeAsync(
                new Clinic
                {
                    Id = Guid.NewGuid(),
                    Name = "City Clinic",
                    Title = "General Clinic",
                    PictureUrl = "https://example.com/clinic1.jpg",
                    Specialty = "General",
                    Address = "123 Main St",
                    DetailedAddress = "Suite 101",
                    MapUrl = "https://maps.example.com/clinic1",
                    AllowNewPatientBooking = true,
                    AllowPatientBooking = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Clinic
                {
                    Id = Guid.NewGuid(),
                    Name = "Health Clinic",
                    Title = "Specialized Clinic",
                    PictureUrl = "https://example.com/clinic2.jpg",
                    Specialty = "Cardiology",
                    Address = "456 Health St",
                    DetailedAddress = "Suite 202",
                    MapUrl = "https://maps.example.com/clinic2",
                    AllowNewPatientBooking = true,
                    AllowPatientBooking = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

        if (!await context.Appointments.AnyAsync())
        {
            await context.Appointments.AddRangeAsync(
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    PatientName = "John Doe",
                    PatientPhone = "555-1234",
                    StartAt = DateTime.UtcNow.AddHours(1),
                    EndAt = DateTime.UtcNow.AddHours(2),
                    Type = "Consultation",
                    Status = 1,
                    ClinicId = Guid.NewGuid(),
                    Notes = "First-time visit",
                    BookingChannel = "Online"
                },
                new Appointment
                {
                    Id = Guid.NewGuid(),
                    PatientName = "Jane Smith",
                    PatientPhone = "555-5678",
                    StartAt = DateTime.UtcNow.AddDays(1),
                    EndAt = DateTime.UtcNow.AddDays(1).AddHours(1),
                    Type = "Follow-up",
                    Status = 1,
                    ClinicId = Guid.NewGuid(),
                    Notes = "Follow-up for previous consultation",
                    BookingChannel = "Phone"
                }
            );
        }

        if (!await context.Availabilities.AnyAsync())
        {
            await context.Availabilities.AddRangeAsync(
                new Availability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    DayOfWeek = 1, // Monday
                    StartTime = new DateTime(9, 0, 0),
                    EndTime = new DateTime(17, 0, 0)
                },
                new Availability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    DayOfWeek = 2, // Tuesday
                    StartTime = new DateTime(9, 0, 0),
                    EndTime = new DateTime(17, 0, 0)
                }
            );
        }

        if (!await context.Unavailabilities.AnyAsync())
        {
            await context.Unavailabilities.AddRangeAsync(
                new Unavailability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    Date = DateTime.UtcNow.Date,
                    StartTime = TimeSpan.FromHours(DateTime.UtcNow.AddHours(-1).Hour), // Changed to TimeSpan
                    EndTime = TimeSpan.FromHours(DateTime.UtcNow.AddHours(1).Hour),    // Changed to TimeSpan
                    IsAllDay = false
                },
                new Unavailability
                {
                    Id = Guid.NewGuid(),
                    ClinicId = Guid.NewGuid(),
                    Date = DateTime.UtcNow.AddDays(2).Date,
                    StartTime = TimeSpan.FromHours(DateTime.UtcNow.AddDays(2).Hour),                // Changed to TimeSpan
                    EndTime = TimeSpan.FromHours(DateTime.UtcNow.AddDays(2).AddHours(3).Hour),      // Changed to TimeSpan
                    IsAllDay = false
                }
            );
        }

        await context.SaveChangesAsync();
    }
}