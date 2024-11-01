using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.Services;
using AppointmentManagement.DTO;

namespace AppointmentManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentTypeController(IAppointmentTypeService appointmentTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentTypeDto>>> GetAllAppointmentTypes()
        {
            var appointmentTypes = await appointmentTypeService.GetAllAppointmentTypes();
            return Ok(appointmentTypes);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentTypeDto>> CreateAppointmentType([FromBody] CreateAppointmentTypeDto createAppointmentTypeDto)
        {
            var newAppointmentType = await appointmentTypeService.CreateAppointmentType(createAppointmentTypeDto);
            return CreatedAtAction(nameof(GetAllAppointmentTypes), new { id = newAppointmentType.Id }, newAppointmentType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentType(Guid id)
        {
            var deleted = await appointmentTypeService.DeleteAppointmentType(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}