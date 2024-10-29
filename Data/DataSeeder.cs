using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AppointmentManagement.Data
{
    public static class DataSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Check if any appointments already exist
            if (!context.Appointments.Any())
            {
                // Seed initial data
                context.Appointments.Add(new Appointment
                {
                    ProfessionalId = "P123",
                    ClinicId = Guid.NewGuid(),
                    PatientId = "PAT001",
                    PatientName = "John Doe",
                    PatientPhone = "555-1234",
                    StartAt = DateTime.Now.AddDays(1),
                    EndAt = DateTime.Now.AddDays(1).AddHours(1),
                    Type = "Consultation",
                    Status = 1,
                    Notes = "First-time consultation",
                    ShowedUp = false,
                    BookingChannel = "Online"
                });

                context.SaveChanges();
            }
        }
    }
}