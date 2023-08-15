using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gFit.Repositories.Implementation
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly DataContext _context;

        public ExerciseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            return await _context.Exercise.ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(Guid id)
        {
            return await _context.Exercise.FindAsync(id);
        }

        public async Task<Exercise> CreateExerciseAsync(Exercise exercise)
        {
            _context.Exercise.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<Exercise> UpdateExerciseAsync(Guid id, Exercise exercise)
        {
            var existingExercise = await _context.Exercise.FindAsync(id);

            if (existingExercise == null)
            {
                return null;
            }

            existingExercise.Name = exercise.Name;
            existingExercise.Description = exercise.Description;
            existingExercise.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingExercise;
        }

        public async Task DeleteExerciseAsync(Guid id)
        {
            var exercise = await _context.Exercise.FindAsync(id);

            if (exercise != null)
            {
                _context.Exercise.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }
    }
}
