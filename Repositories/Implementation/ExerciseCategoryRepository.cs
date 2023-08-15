using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gFit.Repositories.Implementation
{
    public class ExerciseCategoryRepository : IExerciseCategoryRepository
    {
        private readonly DataContext _context;

        public ExerciseCategoryRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseCategory>> GetAllExerciseCategoriesAsync()
        {
            return await _context.ExerciseCategory.ToListAsync();
        }

        public async Task<ExerciseCategory> GetExerciseCategoryByIdAsync(Guid id)
        {
            return await _context.ExerciseCategory.FindAsync(id);
        }

        public async Task<ExerciseCategory> CreateExerciseCategoryAsync(ExerciseCategory exerciseCategory)
        {
            _context.ExerciseCategory.Add(exerciseCategory);
            await _context.SaveChangesAsync();
            return exerciseCategory;
        }

        public async Task<ExerciseCategory> UpdateExerciseCategoryAsync(Guid id, ExerciseCategory exerciseCategory)
        {
            var existingCategory = await _context.ExerciseCategory.FindAsync(id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = exerciseCategory.Name;
            existingCategory.Description = exerciseCategory.Description;
            existingCategory.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingCategory;
        }

        public async Task DeleteExerciseCategoryAsync(Guid id)
        {
            var exerciseCategory = await _context.ExerciseCategory.FindAsync(id);

            if (exerciseCategory != null)
            {
                _context.ExerciseCategory.Remove(exerciseCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
