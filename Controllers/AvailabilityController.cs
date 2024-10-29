namespace AppointmentManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.Services;
using AppointmentManagement.DTO;
using AppointmentManagement.Services;

[ApiController]
[Route("api/[controller]")]
public class AvailabilityController : ControllerBase
{
    private readonly IAvailabilityService _availabilityService;

    public AvailabilityController(IAvailabilityService availabilityService)
    {
        _availabilityService = availabilityService;
    }

    // Get unavailabilities for a specific clinic within a date range
    [HttpGet("clinic/{clinicId}/unavailabilities")]
    public async Task<ActionResult<IEnumerable<UnavailabilityDto>>> GetClinicUnavailabilities(Guid clinicId, DateTime startDate, DateTime endDate)
    {
        try
        {
        var unavailabilities = await _availabilityService.GetClinicUnavailabilities(clinicId, startDate, endDate);
        return Ok(unavailabilities);
            
        }
        catch (Exception ex)
        {
            return BadRequest("Something went wrong");
        }
    }

    // Create availability records
    [HttpPost]
    public async Task<IActionResult> CreateAvailabilities(Guid clinicId, [FromBody] List<AvailabilityDto> availabilityDtos)
    {
        await _availabilityService.CreateAvailabilities(clinicId, availabilityDtos);
        return StatusCode(201); // HTTP 201 Created
    }

    // Get all availabilities for a clinic
    [HttpGet("clinic/{clinicId}")]
    public async Task<ActionResult<IEnumerable<AvailabilityDto>>> GetClinicAvailabilities(Guid clinicId)
    {
        var availabilities = await _availabilityService.GetClinicAvailabilities(clinicId);
        return Ok(availabilities);
    }

    // Remove an availability by ID
    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAvailability(Guid id)
    {
        await _availabilityService.RemoveAvailability(id);
        return NoContent();
    }
}