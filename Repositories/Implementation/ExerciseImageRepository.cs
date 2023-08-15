using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gFit.Repositories.Implementation
{
    public class ExerciseImageRepository : IExerciseImageRepository
    {
        private readonly DataContext _context;

        public ExerciseImageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExerciseImage>> GetAllExerciseImagesAsync()
        {
            return await _context.ExerciseImage.ToListAsync();
        }

        public async Task<ExerciseImage> GetExerciseImageByIdAsync(Guid id)
        {
            return await _context.ExerciseImage.FindAsync(id);
        }

        public async Task<ExerciseImage> CreateExerciseImageAsync(ExerciseImage exerciseImage)
        {
            _context.ExerciseImage.Add(exerciseImage);
            await _context.SaveChangesAsync();
            return exerciseImage;
        }

        public async Task<ExerciseImage> UpdateExerciseImageAsync(Guid id, ExerciseImage exerciseImage)
        {
            var existingImage = await _context.ExerciseImage.FindAsync(id);

            if (existingImage == null)
            {
                return null;
            }

            existingImage.ImageUrl = exerciseImage.ImageUrl;
            existingImage.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingImage;
        }

        public async Task DeleteExerciseImageAsync(Guid id)
        {
            var exerciseImage = await _context.ExerciseImage.FindAsync(id);

            if (exerciseImage != null)
            {
                _context.ExerciseImage.Remove(exerciseImage);
                await _context.SaveChangesAsync();
            }
        }
    }

}
