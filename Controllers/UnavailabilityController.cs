using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.Services;
using AppointmentManagement.DTO;

namespace AppointmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnavailabilityController : ControllerBase
    {
        private readonly IUnavailabilityService _unavailabilityService;

        public UnavailabilityController(IUnavailabilityService unavailabilityService)
        {
            _unavailabilityService = unavailabilityService;
        }

        [HttpGet("{clinicId}")]
        public async Task<ActionResult<IEnumerable<UnavailabilityDto>>> GetUnavailability(Guid clinicId)
        {
            var unavailabilities = await _unavailabilityService.GetUnavailabilityByClinicId(clinicId);
            return Ok(unavailabilities);
        }

        [HttpPost]
        public async Task<ActionResult<UnavailabilityDto>> CreateUnavailability([FromBody] CreateUnavailabilityDto createUnavailabilityDto)
        {
            var newUnavailability = await _unavailabilityService.CreateUnavailability(createUnavailabilityDto);
            return CreatedAtAction(nameof(GetUnavailability), new { clinicId = newUnavailability.ClinicId }, newUnavailability);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnavailability(Guid id)
        {
            var deleted = await _unavailabilityService.DeleteUnavailability(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}