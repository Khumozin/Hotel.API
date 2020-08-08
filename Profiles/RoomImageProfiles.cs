using AutoMapper;
using Hotel.API.Models;

namespace Hotel.API.Profiles
{
    public class RoomImageProfiles : Profile
    {
        public RoomImageProfiles()
        {
            // Source -> Target
            // CREATE
            CreateMap<RoomImageCreateDto, RoomImage>();
            // READ
            CreateMap<RoomImage, RoomImageReadDto>();
            // UPDATE
            CreateMap<RoomImageUpdateDto, RoomImage>();
            CreateMap<RoomImage, RoomImageUpdateDto>();
        }
    }
}