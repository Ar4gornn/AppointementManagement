public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> GetAllAppointments();
    Task<Appointment> GetAppointmentById(Guid id);
    Task<Appointment> AddAppointment(Appointment appointment);
    Task<Appointment> UpdateAppointment(Appointment appointment);
    Task<bool> DeleteAppointment(Guid id);
}