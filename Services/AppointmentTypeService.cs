using AppointmentManagement.Repositories;
using AppointmentManagement.Models;
using AppointmentManagement.DTO;

namespace AppointmentManagement.Services;
public class AppointmentTypeService : IAppointmentTypeService
{
    private readonly IAppointmentTypeRepository _appointmentTypeRepo;

    public AppointmentTypeService(IAppointmentTypeRepository appointmentTypeRepo)
    {
        _appointmentTypeRepo = appointmentTypeRepo;
    }

    public async Task<IEnumerable<AppointmentTypeDto>> GetAllAppointmentTypes()
    {
        var appointmentTypes = await _appointmentTypeRepo.GetAllAppointmentTypes();
        return appointmentTypes.Select(a => new AppointmentTypeDto
        {
            Id = a.Id,
            Name = a.Name
        });
    }

    public async Task<AppointmentTypeDto> CreateAppointmentType(CreateAppointmentTypeDto dto)
    {
        var appointmentType = new AppointmentType
        {
            Id = Guid.NewGuid(),
            Name = dto.Name
        };

        await _appointmentTypeRepo.AddAppointmentType(appointmentType);

        return new AppointmentTypeDto
        {
            Id = appointmentType.Id,
            Name = appointmentType.Name
        };
    }

    public async Task<bool> DeleteAppointmentType(Guid id)
    {
        return await _appointmentTypeRepo.DeleteAppointmentType(id);
    }
}