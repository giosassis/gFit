using AutoMapper;
using gFit.Models;
using static gFit.Context.DTOs.ExerciseCategoryDto;

public class ExerciseCategoryProfile : Profile
{
    public ExerciseCategoryProfile()
    {
        CreateMap<ExerciseCategory, ExerciseCategoryReadDTO>();
        CreateMap<ExerciseCategoryReadDTO, ExerciseCategory>();
        CreateMap<ExerciseCategoryCreateDTO, ExerciseCategory>();
        CreateMap<ExerciseCategoryUpdateDTO, ExerciseCategory>();
    }
}
