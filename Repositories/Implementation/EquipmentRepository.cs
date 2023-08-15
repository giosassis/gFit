using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gFit.Repositories.Implementation
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly DataContext _context;

        public EquipmentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentsAsync()
        {
            return await _context.Equipment.ToListAsync();
        }

        public async Task<Equipment> GetEquipmentByIdAsync(Guid id)
        {
            return await _context.Equipment.FindAsync(id);
        }

        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            _context.Equipment.Add(equipment);
            await _context.SaveChangesAsync();
            return equipment;
        }

        public async Task<Equipment> UpdateEquipmentAsync(Guid id, Equipment equipment)
        {
            var existingEquipment = await _context.Equipment.FindAsync(id);

            if (existingEquipment == null)
            {
                return null;
            }

            existingEquipment.Name = equipment.Name;
            existingEquipment.Description = equipment.Description;
            existingEquipment.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingEquipment;
        }

        public async Task DeleteEquipmentAsync(Guid id)
        {
            var equipment = await _context.Equipment.FindAsync(id);

            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
                await _context.SaveChangesAsync();
            }
        }
    }
}