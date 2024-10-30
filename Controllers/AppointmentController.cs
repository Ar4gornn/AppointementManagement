using Microsoft.AspNetCore.Mvc;
using AppointmentManagement.DTO;
using AppointmentManagement.Services;

namespace AppointmentManagement.Controllers
{


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
        public async Task<ActionResult<IEnumerable<ReadAppointmentDto>>> GetAppointmentByClinicId(Guid clinicId, DateTime startDate, DateTime endDate)
        {
            var appointments = await _appointmentService.GetAppointmentByClinicId(clinicId, startDate, endDate);
            return Ok(appointments);
        }

        // Create a new appointment
        [HttpPost]
        public async Task<ActionResult<ReadAppointmentDto>> CreateAppointment(CreateAppointmentDto dto)
        {
            var appointment = await _appointmentService.CreateAppointment(dto);
            return Ok(appointment);
        }

        // Reschedule an existing appointment
        [HttpPut("{appointmentId}/reschedule")]
        public async Task<ActionResult<ReadAppointmentDto>> RescheduleAppointment(Guid appointmentId, DateTime startAt, DateTime endAt)
        {
            var appointment = await _appointmentService.RescheduleAppointment(appointmentId, startAt, endAt);
            return Ok(appointment);
        }

        // Delete an appointment by ID
        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> DeleteAppointment(Guid appointmentId)
        {
            await _appointmentService.DeleteAppointment(appointmentId);
            return NoContent();
        }

        // Update an existing appointment
        [HttpPut("{appointmentId}")]
        public async Task<ActionResult<ReadAppointmentDto>> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto dto)
        {
            var appointment = await _appointmentService.UpdateAppointment(appointmentId, dto);
            return Ok(appointment);
        }

        // Approve an appointment
        [HttpPut("{appointmentId}/approve")]
        public async Task<ActionResult<ReadAppointmentDto>> ApproveAppointment(Guid appointmentId, bool isApproved)
        {
            var appointment = await _appointmentService.ApproveAppointment(appointmentId, isApproved);
            return Ok(appointment);
        }

        // Set appointment as "showed up"
        [HttpPut("{appointmentId}/showed-up")]
        public async Task<ActionResult<ReadAppointmentDto>> SetAppointmentShowedUp(Guid appointmentId, bool showedUp)
        {
            var appointment = await _appointmentService.SetAppointmentShowedUp(appointmentId, showedUp);
            return Ok(appointment);
        }

        // Get all appointments by Patient ID within a date range
        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<IEnumerable<ReadAppointmentDto>>> GetAppointmentByPatientID(string patientId, DateTime from, DateTime to)
        {
            var appointments = await _appointmentService.GetAppointmentByPatientID(patientId, from, to);
            return Ok(appointments);
        }
    }
}
