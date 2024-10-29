public class UnavailabilityService : IUnavailabilityService
{
    private readonly IUnavailabilityRepository _unavailabilityRepo;

    public UnavailabilityService(IUnavailabilityRepository unavailabilityRepo)
    {
        _unavailabilityRepo = unavailabilityRepo;
    }

    public async Task<IEnumerable<UnavailabilityDto>> GetUnavailabilityByClinicId(Guid clinicId)
    {
        var unavailabilities = await _unavailabilityRepo.GetUnavailabilityByClinicId(clinicId);
        return unavailabilities.Select(u => new UnavailabilityDto
        {
            Id = u.Id,
            ClinicId = u.ClinicId,
            StartTime = u.StartTime,
            EndTime = u.EndTime,
            IsAllDay = u.IsAllDay
        });
    }

    public async Task<UnavailabilityDto> CreateUnavailability(CreateUnavailabilityDto dto)
    {
        var unavailability = new Unavailability
        {
            Id = Guid.NewGuid(),
            ClinicId = dto.ClinicId,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            IsAllDay = dto.IsAllDay
        };

        await _unavailabilityRepo.AddUnavailability(unavailability);

        return new UnavailabilityDto
        {
            Id = unavailability.Id,
            ClinicId = unavailability.ClinicId,
            StartTime = unavailability.StartTime,
            EndTime = unavailability.EndTime,
            IsAllDay = unavailability.IsAllDay
        };
    }

    public async Task<bool> DeleteUnavailability(Guid id)
    {
        return await _unavailabilityRepo.DeleteUnavailability(id);
    }
}