using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface ITrainingSeriesRepository
    {
        Task<IEnumerable<TrainingSeries>> GetAllTrainingSeriesAsync();
        Task<TrainingSeries> GetTrainingSeriesByIdAsync(Guid id);
        Task<TrainingSeries> CreateTrainingSeriesAsync(TrainingSeries trainingSeries);
        Task<TrainingSeries> UpdateTrainingSeriesAsync(Guid id, TrainingSeries trainingSeries);
        Task DeleteTrainingSeriesAsync(Guid id);
    }
}