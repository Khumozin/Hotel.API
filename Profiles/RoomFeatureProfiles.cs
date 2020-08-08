using AutoMapper;
using Hotel.API.Models;

namespace Hotel.API.Profiles
{
    public class RoomFeatureProfiles : Profile
    {
        public RoomFeatureProfiles()
        {
            // Source -> Target
            // CREATE
            CreateMap<RoomFeatureCreateDto, RoomFeature>();
            // READ
            CreateMap<RoomFeature, RoomFeatureReadDto>();
            // UPDATE
            CreateMap<RoomFeatureUpdateDto, RoomFeature>();
            CreateMap<RoomFeature, RoomFeatureUpdateDto>();
        }
    }
}