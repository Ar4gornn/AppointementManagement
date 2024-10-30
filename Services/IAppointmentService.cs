using AppointmentManagement.DTO;

namespace AppointmentManagement.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<ReadAppointmentDto>> GetAppointmentByClinicId(Guid clinicId, DateTime startDate, DateTime endDate);
        Task<ReadAppointmentDto> CreateAppointment(CreateAppointmentDto createAppointmentDto);
        Task<ReadAppointmentDto> RescheduleAppointment(Guid appointmentId, DateTime startAt, DateTime endAt);
        Task DeleteAppointment(Guid appointmentId);
        Task<ReadAppointmentDto> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto updateAppointmentDto);
        Task ApproveAppointment(Guid appointmentId, bool isApproved);
        Task SetAppointmentShowedUp(Guid appointmentId, bool showedUp);
        Task<IEnumerable<ReadAppointmentDto>> GetAppointmentByPatientId(string patientId);
    }
}