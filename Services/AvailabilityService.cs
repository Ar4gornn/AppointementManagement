using AppointmentManagement.DTO;
using AppointmentManagement.Repositories;
using AppointmentManagement.Models;

namespace AppointmentManagement.Services;
public class AvailabilityService(IAvailabilityRepository availabilityRepository) : IAvailabilityService
{
    // Get unavailabilities for a specific clinic within a date range
    public async Task<IEnumerable<UnavailabilityDto>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate)
    {
        var unavailabilities = await availabilityRepository.GetClinicUnavailabilities(clinicId, startDate, endDate);
        return unavailabilities.Select(u => new UnavailabilityDto
        {
            Id = u.Id,
            ClinicId = u.ClinicId,
            StartTime = startDate.Date + u.StartTime, // Fixed
            EndTime = startDate.Date + u.EndTime,     // Fixed
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
            StartTime = new DateTime(a.StartTime.Ticks), // Fixed
            EndTime = new DateTime(a.EndTime.Ticks)      // Fixed
        }).ToList();

        await availabilityRepository.CreateAvailabilities(availabilityEntities);
    }

    // Get all availabilities for a clinic
    public async Task<IEnumerable<AvailabilityDto>> GetClinicAvailabilities(Guid clinicId)
    {
        var availabilities = await availabilityRepository.GetClinicAvailabilities(clinicId);
        return availabilities.Select(a => new AvailabilityDto
        {
            Id = a.Id,
            ClinicId = a.ClinicId,
            DayOfWeek = a.DayOfWeek,
            StartTime = new TimeSpan(a.StartTime.Ticks), // Fixed
            EndTime = new TimeSpan(a.EndTime.Ticks)      // Fixed
        }).ToList();
    }

    // Remove an availability by ID
    public async Task<bool> RemoveAvailability(Guid id)
    {
        return await availabilityRepository.RemoveAvailability(id);
    }
}