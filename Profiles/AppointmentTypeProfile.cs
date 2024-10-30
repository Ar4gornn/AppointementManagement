using AutoMapper;
using AppointmentManagement.DTO;
using AppointmentManagement.Models;

namespace AppointmentManagement.Profiles
{
    public class AppointmentTypeProfile : Profile
    {
        public AppointmentTypeProfile()
        {
            CreateMap<CreateAppointmentTypeDto, AppointmentType>();
            CreateMap<AppointmentType, AppointmentTypeDto>();
        }
    }
}