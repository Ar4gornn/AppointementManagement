using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.Services;
using AppointmentManagement.DTO;

namespace AppointmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnavailabilityController(IUnavailabilityService unavailabilityService) : ControllerBase
    {
        [HttpGet("{clinicId}")]
        public async Task<ActionResult<IEnumerable<UnavailabilityDto>>> GetUnavailability(Guid clinicId)
        {
            var unavailabilities = await unavailabilityService.GetUnavailabilityByClinicId(clinicId);
            return Ok(unavailabilities);
        }

        [HttpPost]
        public async Task<ActionResult<UnavailabilityDto>> CreateUnavailability([FromBody] CreateUnavailabilityDto createUnavailabilityDto)
        {
            var newUnavailability = await unavailabilityService.CreateUnavailability(createUnavailabilityDto);
            return CreatedAtAction(nameof(GetUnavailability), new { clinicId = newUnavailability.ClinicId }, newUnavailability);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnavailability(Guid id)
        {
            var deleted = await unavailabilityService.DeleteUnavailability(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}