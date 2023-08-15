using AutoMapper;
using gFit.Models;
using static gFit.Context.DTOs.ExerciseImageDto;

public class ExerciseImageProfile : Profile
{
    public ExerciseImageProfile()
    {
        CreateMap<ExerciseImage, ExerciseImageReadDTO>();
        CreateMap<ExerciseImageReadDTO, ExerciseImage>();
        CreateMap<ExerciseImageCreateDTO, ExerciseImage>();
        CreateMap<ExerciseImageUpdateDTO, ExerciseImage>();
    }
}
