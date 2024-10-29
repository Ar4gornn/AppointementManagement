public interface IAppointmentTypeService
{
    Task<IEnumerable<AppointmentTypeDto>> GetAllAppointmentTypes();
    Task<AppointmentTypeDto> CreateAppointmentType(CreateAppointmentTypeDto dto);
    Task<bool> DeleteAppointmentType(Guid id);
}