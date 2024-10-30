using AppointmentManagement.DTO;
using AppointmentManagement.Repositories;
using AppointmentManagement.Models;

namespace AppointmentManagement.Services;
public class AvailabilityService : IAvailabilityService
{
    private readonly IAvailabilityRepository _availabilityRepository;

    public AvailabilityService(IAvailabilityRepository availabilityRepository)
    {
        _availabilityRepository = availabilityRepository;
    }

    // Get unavailabilities for a specific clinic within a date range
    public async Task<IEnumerable<UnavailabilityDto>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate)
    {
        var unavailabilities = await _availabilityRepository.GetClinicUnavailabilities(clinicId, startDate, endDate);
        return unavailabilities.Select(u => new UnavailabilityDto
        {
            Id = u.Id,
            ClinicId = u.ClinicId,
            StartTime = u.StartTime,
            EndTime = u.EndTime,
            IsAllDay = u.IsAllDay
        }).ToList();
    }

    // Create availability records
    public async Task CreateAvailabilities(Guid clinicId, List<CreateAvailabilityDto> availabilities)
    {
        var availabilityEntities = availabilities.Select(a => new Availability
        {
            ClinicId = clinicId,
            DayOfWeek = a.DayOfWeek,
            StartTime = a.StartTime,
            EndTime = a.EndTime
        }).ToList();

        await _availabilityRepository.CreateAvailabilities(availabilityEntities);
    }

    // Get all availabilities for a clinic
    public async Task<IEnumerable<AvailabilityDto>> GetClinicAvailabilities(Guid clinicId)
    {
        var availabilities = await _availabilityRepository.GetClinicAvailabilities(clinicId);
        return availabilities.Select(a => new AvailabilityDto
        {
            Id = a.Id,
            ClinicId = a.ClinicId,
            DayOfWeek = a.DayOfWeek,
            StartTime = a.StartTime,
            EndTime = a.EndTime
        }).ToList();
    }

    // Remove an availability by ID
    public async Task<bool> RemoveAvailability(Guid id)
    {
        return await _availabilityRepository.RemoveAvailability(id);
    }
}
