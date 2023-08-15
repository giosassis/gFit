using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IExerciseCategoryRepository
    {
        Task<IEnumerable<ExerciseCategory>> GetAllExerciseCategoriesAsync();
        Task<ExerciseCategory> GetExerciseCategoryByIdAsync(Guid id);
        Task<ExerciseCategory> CreateExerciseCategoryAsync(ExerciseCategory category);
        Task<ExerciseCategory> UpdateExerciseCategoryAsync(Guid id, ExerciseCategory category);
        Task DeleteExerciseCategoryAsync(Guid id);
    }
}
