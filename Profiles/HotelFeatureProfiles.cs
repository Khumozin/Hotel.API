using AutoMapper;
using Hotel.API.Dtos;
using Hotel.API.Models;

namespace Hotel.API.Profiles
{
    public class HotelFeatureProfiles : Profile
    {
        public HotelFeatureProfiles()
        {
            // Source -> Target
            // READ
            CreateMap<HotelFeature, HotelFeatureReadDto>();
            // CREATE
            CreateMap<HotelFeatureCreateDto, HotelFeature>();
            // UPDATE
            CreateMap<HotelFeatureUpdateDto, HotelFeature>();
            CreateMap<HotelFeature, HotelFeatureUpdateDto>();
        }
    }
}