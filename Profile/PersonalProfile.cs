using AutoMapper;
using gFit.Context.DTOs;
using gFit.Models;
using static gFit.Context.DTOs.PersonalDto;

public class PersonalProfile : Profile
{
    public PersonalProfile()
    {
        CreateMap<Personal, PersonalReadDTO>();
        CreateMap<PersonalReadDTO, Personal>();
        CreateMap<PersonalCreateDTO, Personal>();
        CreateMap<PersonalUpdateDTO, Personal>();
    }
}
