using AppointmentManagement.Data;
using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(Guid id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> DeleteAppointment(Guid id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByClinicId(Guid clinicId, DateTime startDate, DateTime endDate)
        {
            return await _context.Appointments
                .Where(a => a.ClinicId == clinicId && a.StartAt >= startDate && a.EndAt <= endDate)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(string patientId, DateTime from, DateTime to)
        {
            return await _context.Appointments
                .Where(a => a.PatientId == patientId && a.StartAt >= from && a.EndAt <= to)
                .ToListAsync();
        }
    }
}