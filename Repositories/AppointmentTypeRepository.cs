namespace AppointmentManagement.Repositories;

public class AppointmentTypeRepository : IAppointmentTypeRepository
{
    private readonly AppDbContext _context;

    public AppointmentTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AppointmentType>> GetAllAppointmentTypes()
    {
        return await _context.AppointmentTypes.ToListAsync();
    }

    public async Task<AppointmentType> AddAppointmentType(AppointmentType appointmentType)
    {
        _context.AppointmentTypes.Add(appointmentType);
        await _context.SaveChangesAsync();
        return appointmentType;
    }

    public async Task<bool> DeleteAppointmentType(Guid id)
    {
        var appointmentType = await _context.AppointmentTypes.FindAsync(id);
        if (appointmentType == null) return false;

        _context.AppointmentTypes.Remove(appointmentType);
        await _context.SaveChangesAsync();
        return true;
    }
}
