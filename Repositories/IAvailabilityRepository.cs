namespace AppointmentManagement.Repositories;

public interface IAvailabilityRepository
{
    Task<IEnumerable<Availability>> GetAvailabilityByClinicId(Guid clinicId);
    Task<Availability> AddAvailability(Availability availability);
    Task<bool> DeleteAvailability(Guid id);
}
