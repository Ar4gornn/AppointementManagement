using AppointmentManagement.Data;
using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Repositories
{
    public class Appointment
    {
    }

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Models.Appointment>> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Models.Appointment> GetAppointmentById(Guid id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task<Models.Appointment> AddAppointment(Models.Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Models.Appointment> UpdateAppointment(Models.Appointment appointment)
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
    }
}