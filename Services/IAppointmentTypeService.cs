using AppointmentManagement.DTO;


namespace AppointmentManagement.Services;
public interface IAppointmentTypeService
{
    Task<IEnumerable<AppointmentTypeDto>> GetAllAppointmentTypes();
    Task<AppointmentTypeDto> CreateAppointmentType(CreateAppointmentTypeDto dto);
    Task<bool> DeleteAppointmentType(Guid id);
}
