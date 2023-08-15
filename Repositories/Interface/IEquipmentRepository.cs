using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentsAsync();
        Task<Equipment> GetEquipmentByIdAsync(Guid id);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task<Equipment> UpdateEquipmentAsync(Guid id, Equipment equipment);
        Task DeleteEquipmentAsync(Guid id);
    }
}

