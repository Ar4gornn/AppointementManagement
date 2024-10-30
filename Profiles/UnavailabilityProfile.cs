using AutoMapper;
using AppointmentManagement.DTO;
using AppointmentManagement.Models;

namespace AppointmentManagement.Profiles
{
    public class UnavailabilityProfile : Profile
    {
        public UnavailabilityProfile()
        {
            CreateMap<CreateUnavailabilityDto, Unavailability>();
            CreateMap<Unavailability, UnavailabilityDto>();
        }
    }
}