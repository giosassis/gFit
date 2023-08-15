using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gFit.Repositories.Implementation
{
    public class MuscleRepository : IMuscleRepository
    {
        private readonly DataContext _context;

        public MuscleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Muscle>> GetAllMusclesAsync()
        {
            return await _context.Muscle.ToListAsync();
        }

        public async Task<Muscle> GetMuscleByIdAsync(Guid id)
        {
            return await _context.Muscle.FindAsync(id);
        }

        public async Task<Muscle> CreateMuscleAsync(Muscle muscle)
        {
            _context.Muscle.Add(muscle);
            await _context.SaveChangesAsync();
            return muscle;
        }

        public async Task<Muscle> UpdateMuscleAsync(Guid id, Muscle muscle)
        {
            var existingMuscle = await _context.Muscle.FindAsync(id);

            if (existingMuscle == null)
            {
                return null;
            }

            existingMuscle.Name = muscle.Name;
            existingMuscle.Description = muscle.Description;
            existingMuscle.UpdatedAt = DateTime.UtcNow;


            await _context.SaveChangesAsync();
            return existingMuscle;
        }

        public async Task DeleteMuscleAsync(Guid id)
        {
            var muscle = await _context.Muscle.FindAsync(id);

            if (muscle != null)
            {
                _context.Muscle.Remove(muscle);
                await _context.SaveChangesAsync();
            }
        }
    }
}
