using System;
using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(Guid id);
        Task<Exercise> CreateExerciseAsync(Exercise exercise);
        Task<Exercise> UpdateExerciseAsync(Guid id, Exercise exercise);
        Task DeleteExerciseAsync(Guid id);
    }
}


