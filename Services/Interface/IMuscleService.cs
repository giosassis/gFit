using gFit.Models;
using static gFit.Context.DTOs.MuscleDto;

namespace gFit.Services.Interface
{
    public interface IMuscleService
    {
        Task<IEnumerable<MuscleReadDTO>> GetAllMusclesAsync();
        Task<MuscleReadDTO> GetMuscleByIdAsync(Guid id);
        Task<MuscleReadDTO> CreateMuscleAsync(MuscleCreateDTO muscleCreateDTO);
        Task<MuscleReadDTO> UpdateMuscleAsync(Guid id, MuscleUpdateDTO muscleUpdateDTO);
        Task DeleteMuscleAsync(Guid id);
    }
}

