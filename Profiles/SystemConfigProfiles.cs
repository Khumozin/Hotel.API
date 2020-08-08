using AutoMapper;
using Hotel.API.Models;

namespace Hotel.API.Profiles
{
    public class SystemConfigProfiles : Profile
    {
        public SystemConfigProfiles()
        {
            // Source -> Target
            CreateMap<SystemConfig, SystemConfigReadDto>();
            CreateMap<SystemConfigCreateDto, SystemConfig>();
            CreateMap<SystemConfigUpdateDto, SystemConfig>();
            CreateMap<SystemConfig, SystemConfigUpdateDto>();
        }
    }
}