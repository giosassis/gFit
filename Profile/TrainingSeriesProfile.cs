using AutoMapper;
using static gFit.Context.DTOs.TrainingSeries;

public class TrainingSeriesProfile : Profile
{
    public TrainingSeriesProfile()
    {
        CreateMap<gFit.Models.TrainingSeries, TrainingSeriesReadDTO>()
            .ForMember(dest => dest.Exercises, opt => opt.MapFrom(src => src.Exercises));
        CreateMap<TrainingSeriesReadDTO, gFit.Models.TrainingSeries>();
        CreateMap<TrainingSeriesCreateDTO, gFit.Models.TrainingSeries>()
            .ForMember(dest => dest.Exercises, opt => opt.Ignore());
        CreateMap<TrainingSeriesUpdateDTO, gFit.Models.TrainingSeries>()
            .ForMember(dest => dest.Exercises, opt => opt.Ignore());
    }
}
