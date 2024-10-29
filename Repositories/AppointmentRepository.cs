using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentManagement.Data;
using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Repositories;
public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentsByClinicId(Guid clinicId, DateTime startDate, DateTime endDate)
    {
        return await _context.Appointments
            .Where(a => a.ClinicId == clinicId && a.StartAt >= startDate && a.EndAt <= endDate)
            .ToListAsync();
    }

    public async Task AddAppointment(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<Appointment> GetAppointmentById(Guid appointmentId)
    {
        return await _context.Appointments.FindAsync(appointmentId);
    }

    public async Task UpdateAppointment(Appointment appointment)
    {
        _context.Entry(appointment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAppointment(Guid appointmentId)
    {
        var appointment = await GetAppointmentById(appointmentId);
        if (appointment != null)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Appointment>> GetAppointmentByPatientID(string patientId)
    {
        return await _context.Appointments
            .Where(a => a.PatientId == patientId)
            .ToListAsync();
    }
}
