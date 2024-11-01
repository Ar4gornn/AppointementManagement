using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.DTO;
using AppointmentManagement.Services;

namespace AppointmentManagement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AvailabilityController(IAvailabilityService availabilityService) : ControllerBase
{
    // Get unavailabilities for a specific clinic within a date range
    [HttpGet("unavailabilities")]
    public async Task<ActionResult<IEnumerable<UnavailabilityDto>>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate)
    {
        var unavailabilities = await availabilityService.GetClinicUnavailabilities(clinicId, startDate, endDate);
        return Ok(unavailabilities);
    }

    // Create availability records
    [HttpPost("availabilities")]
    public async Task<IActionResult> CreateAvailabilities(Guid clinicId, List<CreateAvailabilityDto> availabilities)
    {
        await availabilityService.CreateAvailabilities(clinicId, availabilities);
        return StatusCode(201);
    }

    // Get all availabilities for a clinic
    [HttpGet("availabilities/{clinicId}")]
    public async Task<ActionResult<IEnumerable<AvailabilityDto>>> GetClinicAvailabilities(Guid clinicId)
    {
        var availabilities = await availabilityService.GetClinicAvailabilities(clinicId);
        return Ok(availabilities);
    }

    // Remove an availability by ID
    [HttpDelete("availabilities/{id}")]
    public async Task<IActionResult> RemoveAvailability(Guid id)
    {
        var removed = await availabilityService.RemoveAvailability(id);
        if (!removed)
            return NotFound();
        return NoContent();
    }
}