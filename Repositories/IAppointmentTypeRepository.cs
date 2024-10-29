namespace AppointmentManagement.Repositories;

public interface IAppointmentTypeRepository
{
    Task<IEnumerable<AppointmentType>> GetAllAppointmentTypes();
    Task<AppointmentType> AddAppointmentType(AppointmentType appointmentType);
    Task<bool> DeleteAppointmentType(Guid id);
}
