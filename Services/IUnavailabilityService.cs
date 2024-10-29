using AppointmentManagement.DTO;

public interface IUnavailabilityService
{
    Task<IEnumerable<UnavailabilityDto>> GetUnavailabilityByClinicId(Guid clinicId);
    Task<UnavailabilityDto> CreateUnavailability(CreateUnavailabilityDto dto);
    Task<bool> DeleteUnavailability(Guid id);
}