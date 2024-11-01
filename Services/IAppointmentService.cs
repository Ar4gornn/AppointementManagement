using AppointmentManagement.DTO;

namespace AppointmentManagement.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<ReadAppointmentDto>> GetAppointmentsByClinicId(Guid clinicId, DateTime startDate, DateTime endDate);
        Task<ReadAppointmentDto> CreateAppointment(CreateAppointmentDto createAppointmentDto);
        Task<ReadAppointmentDto> RescheduleAppointment(Guid appointmentId, DateTime startAt, DateTime endAt);
        Task DeleteAppointment(Guid appointmentId);
        Task<ReadAppointmentDto> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto updateAppointmentDto);
        Task<ReadAppointmentDto> ApproveAppointment(Guid appointmentId, bool isApproved);
        Task<IEnumerable<ReadAppointmentDto>> GetAppointmentsByPatientId(string patientId, DateTime from, DateTime to);
    }
}