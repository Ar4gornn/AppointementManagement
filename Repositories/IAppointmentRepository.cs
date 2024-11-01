using AppointmentManagement.Models;

namespace AppointmentManagement.Repositories;
public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAllAppointments();
    Task<Appointment> GetAppointmentById(Guid id);
    Task<Appointment> AddAppointment(Appointment appointment);
    Task<Appointment> UpdateAppointment(Appointment appointment);
    Task<bool> DeleteAppointment(Guid id);
    Task<IEnumerable<Appointment>> GetAppointmentsByClinicId(Guid clinicId, DateTime startDate, DateTime endDate);
    Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(string patientId, DateTime from, DateTime to);
}