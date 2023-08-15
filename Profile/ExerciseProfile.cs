using AutoMapper;
using gFit.Models;
using static gFit.Context.DTOs.ExerciseDto;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<Exercise, ExerciseReadDTO>();
        CreateMap<ExerciseReadDTO, Exercise>();
        CreateMap<ExerciseCreateDTO, Exercise>();
        CreateMap<ExerciseUpdateDTO, Exercise>();
    }
}
