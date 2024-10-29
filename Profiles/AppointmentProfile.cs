using AppointmentManagement.Controllers;
using AutoMapper;
using AppointmentManagement.Models;
using AppointmentManagement.DTO;



namespace AppointmentManagement.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            // Mapping between Appointment and ReadAppointmentDto
            CreateMap<Appointment, ReadAppointmentDto>().ReverseMap();

            // Mapping between CreateAppointmentDto and Appointment
            CreateMap<CreateAppointmentDto, Appointment>();

            // Mapping between UpdateAppointmentDto and Appointment
            CreateMap<UpdateAppointmentDto, Appointment>();
        }
    }
}