using AutoMapper;
using gFit.Models;
using static gFit.Context.DTOs.UserDto;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReadDTO>();
        CreateMap<UserReadDTO, User>();
        CreateMap<UserCreateDTO, User>();
        CreateMap<UserUpdateDTO, User>();
    }
}
