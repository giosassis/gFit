using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gFit.Repositories.Implementation
{
    public class TrainingSeriesRepository : ITrainingSeriesRepository
    {
        private readonly DataContext _context;

        public TrainingSeriesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrainingSeries>> GetAllTrainingSeriesAsync()
        {
            return await _context.TrainingSeries.ToListAsync();
        }

        public async Task<TrainingSeries> GetTrainingSeriesByIdAsync(Guid id)
        {
            return await _context.TrainingSeries.FindAsync(id);
        }

        public async Task<TrainingSeries> CreateTrainingSeriesAsync(TrainingSeries trainingSeries)
        {
            _context.TrainingSeries.Add(trainingSeries);
            await _context.SaveChangesAsync();
            return trainingSeries;
        }

        public async Task<TrainingSeries> UpdateTrainingSeriesAsync(Guid id, TrainingSeries trainingSeries)
        {
            var existingTrainingSeries = await _context.TrainingSeries
            .Include(ts => ts.Exercises) // Inclua os exercícios da série
            .FirstOrDefaultAsync(ts => ts.Id == id);

            if (existingTrainingSeries == null)
            {
                return null;
            }

            existingTrainingSeries.Name = trainingSeries.Name;
            existingTrainingSeries.Description = trainingSeries.Description;
            existingTrainingSeries.Series = trainingSeries.Series;
            existingTrainingSeries.Repetitions = trainingSeries.Repetitions;
            existingTrainingSeries.RestTime = trainingSeries.RestTime;

            foreach (var updatedExercise in trainingSeries.Exercises)
            {
                var existingExercise = existingTrainingSeries.Exercises
                    .FirstOrDefault(e => e.Id == updatedExercise.Id);

                if (existingExercise != null)
                {
                    existingExercise.Name = updatedExercise.Name;
                    existingExercise.Repetitions = updatedExercise.Repetitions;
                    existingExercise.Sets = updatedExercise.Sets;
                    existingExercise.RestInterval = updatedExercise.RestInterval;
                }
            }

            await _context.SaveChangesAsync();
            return existingTrainingSeries;
        }

        public async Task DeleteTrainingSeriesAsync(Guid id)
        {
            var trainingSeries = await _context.TrainingSeries.FindAsync(id);

            if (trainingSeries != null)
            {
                _context.TrainingSeries.Remove(trainingSeries);
                await _context.SaveChangesAsync();
            }
        }
    }
}
