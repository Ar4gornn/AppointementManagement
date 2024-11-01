using AppointmentManagement.Data;
using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Repositories;

public class AvailabilityRepository(AppDbContext context) : IAvailabilityRepository
{
    public async Task<IEnumerable<Unavailability>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate)
    {
        return await context.Unavailabilities
            .Where(u => u.ClinicId == clinicId && u.StartTime >= startDate.TimeOfDay && u.EndTime <= endDate.TimeOfDay)
            .ToListAsync<Unavailability>();
    }

    public async Task CreateAvailabilities(List<Availability> availabilities)
    {
        context.Availabilities.AddRange(availabilities);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Availability>> GetClinicAvailabilities(Guid clinicId)
    {
        return await context.Availabilities
            .Where(a => a.ClinicId == clinicId)
            .ToListAsync<Availability>();
    }

    public async Task<bool> RemoveAvailability(Guid id)
    {
        var availability = await context.Availabilities.FindAsync(id);
        if (availability == null) return false;

        context.Availabilities.Remove(availability);
        await context.SaveChangesAsync();
        return true;
    }
}