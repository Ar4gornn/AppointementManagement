namespace AppointmentManagement.Controllers;
using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.DTO;
using AppointmentManagement.Services;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    // Get all appointments for a specific clinic within a date range
    [HttpGet("clinic/{clinicId}")]
    public async Task<ActionResult<IEnumerable<ReadAppointmentDto>>> GetAppointmentByClinicId(Guid clinicId,
        DateTime startDate, DateTime endDate)
    {
        var appointments = await _appointmentService.GetAppointmentByClinicId(clinicId, startDate, endDate);
        return Ok(appointments);
    }

    // Create a new appointment
    [HttpPost]
    public async Task<ActionResult<ReadAppointmentDto>> CreateAppointment(
        [FromBody] CreateAppointmentDto createAppointmentDto)
    {
        var createdAppointment = await _appointmentService.CreateAppointment(createAppointmentDto);
        return CreatedAtAction(nameof(GetAppointmentByClinicId), new { clinicId = createdAppointment.ClinicId },
            createdAppointment);
    }

    // Reschedule an existing appointment
    [HttpPut("reschedule/{appointmentId}")]
    public async Task<ActionResult<ReadAppointmentDto>> RescheduleAppointment(Guid appointmentId, DateTime startAt,
        DateTime endAt)
    {
        var updatedAppointment = await _appointmentService.RescheduleAppointment(appointmentId, startAt, endAt);
        return Ok(updatedAppointment);
    }

    // Delete an appointment by ID
    //[HttpDelete("{appointmentId}")]
    //public async Task<IActionResult> DeleteAppointment(Guid appointmentId)
    //{
    //    await _appointmentService.DeleteAppointment(appointmentId);
    //    return NoContent();
    //}

    // Update an existing appointment
    [HttpPut("{appointmentId}")]
    public async Task<ActionResult<ReadAppointmentDto>> UpdateAppointment(Guid appointmentId,
        [FromBody] UpdateAppointmentDto updateAppointmentDto)
    {
        var updatedAppointment = await _appointmentService.UpdateAppointment(appointmentId, updateAppointmentDto);
        return Ok(updatedAppointment);
    }

    // Approve an appointment
    [HttpPut("approve/{appointmentId}")]
    public async Task<IActionResult> ApproveAppointment(Guid appointmentId, bool isApproved)
    {
        await _appointmentService.ApproveAppointment(appointmentId, isApproved);
        return NoContent();
    }

    // Set appointment as "showed up"
    [HttpPut("showedUp/{appointmentId}")]
    public async Task<IActionResult> SetAppointmentShowedUp(Guid appointmentId, bool showedUp)
    {
        await _appointmentService.SetAppointmentShowedUp(appointmentId, showedUp);
        return NoContent();
    }

    // Get all appointments by Patient ID
    [HttpGet()]
    public async Task<ActionResult<IEnumerable<ReadAppointmentDto>>> GetAppointmentByPatientID(string patientId,
        DateTime from, DateTime to)
    {
        var appointments = await _appointmentService.GetAppointmentByPatientID(patientId, from, to);
        return Ok(appointments);
    }
}