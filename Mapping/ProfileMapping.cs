

using AutoMapper;
using Crud.Dto;

namespace Crud.Mapping; 

public class ProfileMapping : Profile
{
    public ProfileMapping()
    {
        CreateMap<Profile, ProfileDto>().ReverseMap();
    }
}