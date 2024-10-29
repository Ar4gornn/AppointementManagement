public class AvailabilityService : IAvailabilityService
{
    private readonly IAvailabilityRepository _availabilityRepo;

    public AvailabilityService(IAvailabilityRepository availabilityRepo)
    {
        _availabilityRepo = availabilityRepo;
    }

    public async Task<IEnumerable<AvailabilityDto>> GetAvailabilityByClinicId(Guid clinicId)
    {
        var availabilities = await _availabilityRepo.GetAvailabilityByClinicId(clinicId);
        return availabilities.Select(a => new AvailabilityDto
        {
            Id = a.Id,
            ClinicId = a.ClinicId,
            DayOfWeek = a.DayOfWeek,
            StartTime = a.StartTime,
            EndTime = a.EndTime
        });
    }

    public async Task<AvailabilityDto> CreateAvailability(CreateAvailabilityDto dto)
    {
        var availability = new Availability
        {
            Id = Guid.NewGuid(),
            ClinicId = dto.ClinicId,
            DayOfWeek = dto.DayOfWeek,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime
        };

        await _availabilityRepo.AddAvailability(availability);

        return new AvailabilityDto
        {
            Id = availability.Id,
            ClinicId = availability.ClinicId,
            DayOfWeek = availability.DayOfWeek,
            StartTime = availability.StartTime,
            EndTime = availability.EndTime
        };
    }

    public async Task<bool> DeleteAvailability(Guid id)
    {
        return await _availabilityRepo.DeleteAvailability(id);
    }
}