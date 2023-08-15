using static gFit.Context.DTOs.TrainingSeries;

namespace gFit.Services.Interfaces
{
    public interface ITrainingSeriesService
    {
        Task<IEnumerable<TrainingSeriesReadDTO>> GetAllTrainingSeriesAsync();
        Task<TrainingSeriesReadDTO> GetTrainingSeriesByIdAsync(Guid id);
        Task<TrainingSeriesReadDTO> CreateTrainingSeriesAsync(TrainingSeriesCreateDTO trainingSeriesCreateDTO);
        Task<TrainingSeriesReadDTO> UpdateTrainingSeriesAsync(Guid id, TrainingSeriesUpdateDTO trainingSeriesUpdateDTO);
        Task DeleteTrainingSeriesAsync(Guid id);
    }
}
