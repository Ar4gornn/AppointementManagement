public interface IAvailabilityService
{
    Task<IEnumerable<AvailabilityDto>> GetAvailabilityByClinicId(Guid clinicId);
    Task<AvailabilityDto> CreateAvailability(CreateAvailabilityDto dto);
    Task<bool> DeleteAvailability(Guid id);
}