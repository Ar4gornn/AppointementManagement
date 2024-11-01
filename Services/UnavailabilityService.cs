using AppointmentManagement.Repositories;
using AppointmentManagement.Models;
using AppointmentManagement.DTO;

namespace AppointmentManagement.Services;
public class UnavailabilityService(IUnavailabilityRepository unavailabilityRepo) : IUnavailabilityService
{
    public async Task<IEnumerable<UnavailabilityDto>> GetUnavailabilityByClinicId(Guid clinicId)
    {
        var unavailabilities = await unavailabilityRepo.GetUnavailabilityByClinicId(clinicId);
        return unavailabilities.Select(u => new UnavailabilityDto
        {
            Id = u.Id,
            ClinicId = u.ClinicId,
            StartDateTime = u.Date.Add(u.StartTime),  // Combine Date + TimeSpan
            EndDateTime = u.Date.Add(u.EndTime),      // Combine Date + TimeSpan
            IsAllDay = u.IsAllDay
        }).ToList();
    }

    public async Task<UnavailabilityDto> CreateUnavailability(CreateUnavailabilityDto dto)
    {
        var unavailability = new Unavailability
        {
            Id = Guid.NewGuid(),
            ClinicId = dto.ClinicId,
            Date = dto.StartDateTime.Date,  // Extract Date part from DateTime
            StartTime = dto.StartDateTime.TimeOfDay,  // Extract Time part from DateTime
            EndTime = dto.EndDateTime.TimeOfDay,      // Extract Time part from DateTime
            IsAllDay = dto.IsAllDay
        };

        await unavailabilityRepo.AddUnavailability(unavailability);

        return new UnavailabilityDto
        {
            Id = unavailability.Id,
            ClinicId = unavailability.ClinicId,
            StartDateTime = unavailability.Date.Add(unavailability.StartTime),  // Combine Date + TimeSpan
            EndDateTime = unavailability.Date.Add(unavailability.EndTime),      // Combine Date + TimeSpan
            IsAllDay = unavailability.IsAllDay
        };
    }

    public async Task<bool> DeleteUnavailability(Guid id)
    {
        return await unavailabilityRepo.DeleteUnavailability(id);
    }
}
