using gFit.Context.DTOs;
using gFit.Models;
using static gFit.Context.DTOs.ExerciseImageDto;

namespace gFit.Services.Interface
{
    public interface IExerciseImageService
    {
        Task<IEnumerable<ExerciseImageReadDTO>> GetAllEquipmentImageAsync();
        Task<ExerciseImageReadDTO> GetEquipmentImageByIdAsync(Guid id);
        Task<ExerciseImageReadDTO> CreateEquipmentImageAsync(ExerciseImageCreateDTO equipmentDTO);
        Task<ExerciseImageReadDTO> UpdateEquipmentImageAsync(Guid id, ExerciseImageUpdateDTO equipmentDTO);
        Task DeleteExerciseImageAsync(Guid id);
    }
}
