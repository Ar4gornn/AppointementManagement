using AppointmentManagement.Data;
using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Repositories;

public class AvailabilityRepository : IAvailabilityRepository
{
    private readonly AppDbContext _context;

    public AvailabilityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Unavailability>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate)
    {
        return await _context.Unavailabilities
            .Where(u => u.ClinicId == clinicId && u.StartTime >= startDate.TimeOfDay && u.EndTime <= endDate.TimeOfDay)
            .ToListAsync<Unavailability>();
    }

    public async Task CreateAvailabilities(List<Availability> availabilities)
    {
        _context.Availabilities.AddRange(availabilities);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Availability>> GetClinicAvailabilities(Guid clinicId)
    {
        return await _context.Availabilities
            .Where(a => a.ClinicId == clinicId)
            .ToListAsync<Availability>();
    }

    public async Task<bool> RemoveAvailability(Guid id)
    {
        var availability = await _context.Availabilities.FindAsync(id);
        if (availability == null) return false;

        _context.Availabilities.Remove(availability);
        await _context.SaveChangesAsync();
        return true;
    }
}