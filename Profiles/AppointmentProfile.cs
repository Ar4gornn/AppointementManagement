using AutoMapper;
using AppointmentManagement.DTO;
using AppointmentManagement.Models;

namespace AppointmentManagement.Profiles
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<CreateAppointmentDto, Appointment>();
            CreateMap<Appointment, ReadAppointmentDto>();
            CreateMap<UpdateAppointmentDto, Appointment>();
        }
    }
}