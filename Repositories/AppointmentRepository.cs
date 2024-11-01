using AppointmentManagement.Data;
using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Repositories
{
    public class AppointmentRepository(AppDbContext context) : IAppointmentRepository
    {
        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(Guid id)
        {
            return await context.Appointments.FindAsync(id);
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            context.Appointments.Add(appointment);
            await context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            context.Appointments.Update(appointment);
            await context.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> DeleteAppointment(Guid id)
        {
            var appointment = await context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            context.Appointments.Remove(appointment);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByClinicId(Guid clinicId, DateTime startDate, DateTime endDate)
        {
            return await context.Appointments
                .Where(a => a.ClinicId == clinicId && a.StartAt >= startDate && a.EndAt <= endDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(string patientId, DateTime from, DateTime to)
        {
            Guid patientGuid;
            if (!Guid.TryParse(patientId, out patientGuid))
            {
                throw new ArgumentException("Invalid patient ID format", nameof(patientId));
            }

            return await context.Appointments
                .Where(a => a.PatientId == patientGuid && a.StartAt >= from && a.EndAt <= to)
                .ToListAsync();
        }
    }
}