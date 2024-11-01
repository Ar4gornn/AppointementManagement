using AppointmentManagement.DTO;
using AppointmentManagement.Models;
using AutoMapper;
using AppointmentManagement.Repositories;

namespace AppointmentManagement.Services
{
    public class AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        : IAppointmentService
    {
        // Get appointments by clinic
        public async Task<IEnumerable<ReadAppointmentDto>> GetAppointmentsByClinicId(Guid clinicId, DateTime startDate, DateTime endDate)
        {
            var appointments = await appointmentRepository.GetAppointmentsByClinicId(clinicId, startDate, endDate);
            return mapper.Map<IEnumerable<ReadAppointmentDto>>(appointments);
        }

        public async Task<ReadAppointmentDto> CreateAppointment(CreateAppointmentDto createAppointmentDto)
        {
            var appointment = mapper.Map<Appointment>(createAppointmentDto);
            await appointmentRepository.AddAppointment(appointment);
            return mapper.Map<ReadAppointmentDto>(appointment);
        }

        public async Task<ReadAppointmentDto> RescheduleAppointment(Guid appointmentId, DateTime startAt, DateTime endAt)
        {
            var appointment = await appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            appointment.StartAt = startAt;
            appointment.EndAt = endAt;
            await appointmentRepository.UpdateAppointment(appointment);
            return mapper.Map<ReadAppointmentDto>(appointment);
        }

        public async Task DeleteAppointment(Guid appointmentId)
        {
            await appointmentRepository.DeleteAppointment(appointmentId);
        }

        public async Task<ReadAppointmentDto> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto updateAppointmentDto)
        {
            var appointment = await appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            mapper.Map(updateAppointmentDto, appointment);
            await appointmentRepository.UpdateAppointment(appointment);
            return mapper.Map<ReadAppointmentDto>(appointment);
        }

        public async Task<ReadAppointmentDto> ApproveAppointment(Guid appointmentId, bool isApproved)
        {
            var appointment = await appointmentRepository.GetAppointmentById(appointmentId);
            if (appointment == null) throw new KeyNotFoundException("Appointment not found");

            appointment.Status = isApproved ? 1 : 0; // Example: 1 is approved, 0 is not
            await appointmentRepository.UpdateAppointment(appointment);
            return mapper.Map<ReadAppointmentDto>(appointment);
        }

        public async Task<IEnumerable<ReadAppointmentDto>> GetAppointmentsByPatientId(string patientId, DateTime from, DateTime to)
        {
            var appointments = await appointmentRepository.GetAppointmentsByPatientId(patientId, from, to);
            return mapper.Map<IEnumerable<ReadAppointmentDto>>(appointments);
        }
    }
}