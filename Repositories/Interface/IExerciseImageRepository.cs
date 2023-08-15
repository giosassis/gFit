using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IExerciseImageRepository
    {
        Task<IEnumerable<ExerciseImage>> GetAllExerciseImagesAsync();
        Task<ExerciseImage> GetExerciseImageByIdAsync(Guid id);
        Task<ExerciseImage> CreateExerciseImageAsync(ExerciseImage image);
        Task<ExerciseImage> UpdateExerciseImageAsync(Guid id, ExerciseImage image);
        Task DeleteExerciseImageAsync(Guid id);
    }
}
