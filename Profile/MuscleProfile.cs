using AutoMapper;
using gFit.Context.DTOs;
using gFit.Models;
using static gFit.Context.DTOs.MuscleDto;

public class MuscleProfile : Profile
{
    public MuscleProfile()
    {
        CreateMap<Muscle, MuscleReadDTO>();
        CreateMap<MuscleReadDTO, Muscle>();
        CreateMap<MuscleCreateDTO, Muscle>();
        CreateMap<MuscleUpdateDTO, Muscle>();
    }
}
