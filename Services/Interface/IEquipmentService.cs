using static gFit.Context.DTOs.EquipmentDto;

namespace gFit.Services.Interface
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentReadDTO>> GetAllEquipmentAsync();
        Task<EquipmentReadDTO> GetEquipmentByIdAsync(Guid id);
        Task<EquipmentReadDTO> CreateEquipmentAsync(EquipmentCreateDTO equipmentDTO);
        Task<EquipmentReadDTO> UpdateEquipmentAsync(Guid id, EquipmentUpdateDTO equipmentDTO);
        Task DeleteEquipmentAsync(Guid id);
    }
}

