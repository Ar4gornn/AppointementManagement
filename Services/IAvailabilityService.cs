using AppointmentManagement.DTO;

namespace AppointmentManagement.Services;
public interface IAvailabilityService
{
    Task<IEnumerable<UnavailabilityDto>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate);
    Task CreateAvailabilities(Guid clinicId, List<CreateAvailabilityDto> availabilities);
    Task<IEnumerable<AvailabilityDto>> GetClinicAvailabilities(Guid clinicId);
    Task<bool> RemoveAvailability(Guid id);
}
