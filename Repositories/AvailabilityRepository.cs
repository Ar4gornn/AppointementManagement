namespace AppointmentManagement.Repositories;

public class AvailabilityRepository : IAvailabilityRepository
{
    private readonly AppDbContext _context;

    public AvailabilityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Availability>> GetAvailabilityByClinicId(Guid clinicId)
    {
        return await _context.Availabilities
            .Where(a => a.ClinicId == clinicId)
            .ToListAsync();
    }

    public async Task<Availability> AddAvailability(Availability availability)
    {
        _context.Availabilities.Add(availability);
        await _context.SaveChangesAsync();
        return availability;
    }

    public async Task<bool> DeleteAvailability(Guid id)
    {
        var availability = await _context.Availabilities.FindAsync(id);
        if (availability == null) return false;

        _context.Availabilities.Remove(availability);
        await _context.SaveChangesAsync();
        return true;
    }
}
