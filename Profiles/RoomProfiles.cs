using AutoMapper;
using Hotel.API.Models;

namespace Hotel.API.Profiles
{
    public class RoomProfiles : Profile
    {
        public RoomProfiles()
        {
            // Source -> Target
            // CREATE
            CreateMap<RoomCreateDto, Room>();
            // READ
            CreateMap<Room, RoomReadDto>();
            // UPDATE
            CreateMap<RoomUpdateDto, Room>();
            CreateMap<Room, RoomUpdateDto>();
        }
    }
}