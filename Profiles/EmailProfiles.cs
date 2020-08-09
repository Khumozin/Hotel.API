using AutoMapper;
using Hotel.API.Dtos;
using Hotel.API.Models;

namespace Hotel.API.Profiles
{
    public class EmailProfiles : Profile
    {
        public EmailProfiles()
        {
            // Source -> Target
            // CREATE
            CreateMap<EmailCreateDto, Email>();
            // READ
            CreateMap<Email, EmailReadDto>();
            // UPDATE
            CreateMap<EmailUpdateDto, Email>();
            CreateMap<Email, EmailUpdateDto>();
        }
    }
}