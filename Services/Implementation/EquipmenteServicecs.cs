using AutoMapper;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interface;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static gFit.Context.DTOs.EquipmentDto;

namespace gFit.Services.Implementation
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IMapper mapper, IEquipmentRepository equipmentRepository)
        {
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
        }

        public async Task<IEnumerable<EquipmentReadDTO>> GetAllEquipmentAsync()
        {
            var equipments = await _equipmentRepository.GetAllEquipmentsAsync();
            return _mapper.Map<IEnumerable<EquipmentReadDTO>>(equipments);
        }

        public async Task<EquipmentReadDTO> GetEquipmentByIdAsync(Guid id)
        {
            var equipment = await _equipmentRepository.GetEquipmentByIdAsync(id);
            return _mapper.Map<EquipmentReadDTO>(equipment);
        }

        public async Task<EquipmentReadDTO> CreateEquipmentAsync(EquipmentCreateDTO equipmentCreateDTO)
        {
            var equipment = _mapper.Map<Equipment>(equipmentCreateDTO);

            equipment.CreatedAt = DateTime.UtcNow;
            equipment.UpdatedAt = DateTime.UtcNow;

            var createdEquipment = await _equipmentRepository.CreateEquipmentAsync(equipment);
            return _mapper.Map<EquipmentReadDTO>(createdEquipment);
        }

        public async Task<EquipmentReadDTO> UpdateEquipmentAsync(Guid id, EquipmentUpdateDTO equipmentUpdateDTO)
        {
            var existingEquipment = await _equipmentRepository.GetEquipmentByIdAsync(id);

            if (existingEquipment == null)
            {
                throw new Exception("Equipment not found");
            }

            var updatedEquipment = await _equipmentRepository.UpdateEquipmentAsync(id, existingEquipment);
            return _mapper.Map<EquipmentReadDTO>(updatedEquipment);
        }

        public async Task DeleteEquipmentAsync(Guid id)
        {
            var existingEquipment = await _equipmentRepository.GetEquipmentByIdAsync(id);

            if (existingEquipment == null)
            {
                return;
            }

            await _equipmentRepository.DeleteEquipmentAsync(id);
        }
    }
}
