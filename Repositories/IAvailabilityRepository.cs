using AppointmentManagement.Models;

namespace AppointmentManagement.Repositories;

public interface IAvailabilityRepository
{
    Task<IEnumerable<Unavailability>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate);
    Task CreateAvailabilities(List<Availability> availabilities);
    Task<IEnumerable<Availability>> GetClinicAvailabilities(Guid clinicId);
    Task<bool> RemoveAvailability(Guid id);
}
