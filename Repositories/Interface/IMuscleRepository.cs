using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IMuscleRepository
    {
        Task<IEnumerable<Muscle>> GetAllMusclesAsync();
        Task<Muscle> GetMuscleByIdAsync(Guid id);
        Task<Muscle> CreateMuscleAsync(Muscle muscle);
        Task<Muscle> UpdateMuscleAsync(Guid id, Muscle muscle);
        Task DeleteMuscleAsync(Guid id);
    }
}

