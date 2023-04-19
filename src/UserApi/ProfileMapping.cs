using AutoMapper;
using UserApi.Data.Models;
using UserApi.Models;
#pragma warning disable CS1591

namespace UserApi;

public class ProfileMapping: Profile
{
    public ProfileMapping()
    {
        CreateMap<UserDto, User>()
            .ReverseMap();
    }
}