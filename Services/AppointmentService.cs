using AppointmentManagement.DTO;
using AppointmentManagement.Models;
using AutoMapper;

namespace AppointmentManagement.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadAppointmentDto>> GetAppointmentByClinicId(Guid clinicId, DateTime startDate, DateTime endDate)
        {
            var appointments = await _appointmentRepository.GetAppointmentsByClinicId(clinicId, startDate, endDate);
            return _mapper.Map<IEnumerable<ReadAppointmentDto>>(appointments);
        }

        public async Task<ReadAppointmentDto> CreateAppointment(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(createAppointmentDto);
            await _appointmentRepository.AddAppointment(appointment);
            return _mapper.Map<ReadAppointmentDto>(appointment);
        }

        public async Task<ReadAppointmentDto> RescheduleAppointment(Guid appointmentId, DateTime startAt, DateTime endAt)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            appointment.StartAt = startAt;
            appointment.EndAt = endAt;
            await _appointmentRepository.UpdateAppointment(appointment);
            return _mapper.Map<ReadAppointmentDto>(appointment);
        }

        public async Task DeleteAppointment(Guid appointmentId)
        {
            await _appointmentRepository.DeleteAppointment(appointmentId);
        }

        public async Task<ReadAppointmentDto> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            _mapper.Map(updateAppointmentDto, appointment);
            await _appointmentRepository.UpdateAppointment(appointment);
            return _mapper.Map<ReadAppointmentDto>(appointment);
        }

        public async Task ApproveAppointment(Guid appointmentId, bool isApproved)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            appointment.Status = isApproved ? 1 : 0; // Example: 1 is approved, 0 is not
            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task SetAppointmentShowedUp(Guid appointmentId, bool showedUp)
        {
            var appointment = await _appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            appointment.ShowedUp = showedUp;
            await _appointmentRepository.UpdateAppointment(appointment);
        }

        public async Task<IEnumerable<ReadAppointmentDto>> GetAppointmentByPatientID(string patientId)
        {
            var appointments = await _appointmentRepository.GetAppointmentByPatientID(patientId);
            return _mapper.Map<IEnumerable<ReadAppointmentDto>>(appointments);
        }
    }
}