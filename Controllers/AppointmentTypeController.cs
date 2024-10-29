using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.Services;
using AppointmentManagement.DTO;

namespace AppointmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentTypeController : ControllerBase
    {
        private readonly IAppointmentTypeService _appointmentTypeService;

        public AppointmentTypeController(IAppointmentTypeService appointmentTypeService)
        {
            _appointmentTypeService = appointmentTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentTypeDto>>> GetAllAppointmentTypes()
        {
            var appointmentTypes = await _appointmentTypeService.GetAllAppointmentTypes();
            return Ok(appointmentTypes);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentTypeDto>> CreateAppointmentType([FromBody] CreateAppointmentTypeDto createAppointmentTypeDto)
        {
            var newAppointmentType = await _appointmentTypeService.CreateAppointmentType(createAppointmentTypeDto);
            return CreatedAtAction(nameof(GetAllAppointmentTypes), new { id = newAppointmentType.Id }, newAppointmentType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentType(Guid id)
        {
            var deleted = await _appointmentTypeService.DeleteAppointmentType(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}