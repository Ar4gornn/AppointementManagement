using AutoMapper;
using AppointmentManagement.DTO;
using AppointmentManagement.Models;

namespace AppointmentManagement.Profiles
{
    public class AvailabilityProfile : Profile
    {
        public AvailabilityProfile()
        {
            CreateMap<CreateAvailabilityDto, Availability>();
            CreateMap<Availability, AvailabilityDto>();
        }
    }
}