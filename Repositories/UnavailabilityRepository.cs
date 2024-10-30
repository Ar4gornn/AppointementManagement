using AppointmentManagement.Data;
using AppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagement.Repositories;

public class UnavailabilityRepository(AppDbContext context) : IUnavailabilityRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Unavailability>> GetUnavailabilityByClinicId(Guid clinicId)
    {
        return await _context.Unavailabilities
            .Where(u => u.ClinicId == clinicId)
            .ToListAsync();
    }

    public async Task<Unavailability> AddUnavailability(Unavailability unavailability)
    {
        _context.Unavailabilities.Add(unavailability);
        await _context.SaveChangesAsync();
        return unavailability;
    }

    public async Task<bool> DeleteUnavailability(Guid id)
    {
        var unavailability = await _context.Unavailabilities.FindAsync(id);
        if (unavailability == null) return false;

        _context.Unavailabilities.Remove(unavailability);
        await _context.SaveChangesAsync();
        return true;
    }
}