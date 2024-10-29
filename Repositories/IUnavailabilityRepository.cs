namespace AppointmentManagement.Repositories;

public interface IUnavailabilityRepository
{
    Task<IEnumerable<Unavailability>> GetUnavailabilityByClinicId(Guid clinicId);
    Task<Unavailability> AddUnavailability(Unavailability unavailability);
    Task<bool> DeleteUnavailability(Guid id);
}
