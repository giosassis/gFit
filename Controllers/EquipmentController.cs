using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.EquipmentDto;
using gFit.Services.Implementation;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingSeries()
        {
            var equipment = await _equipmentService.GetAllEquipmentAsync();
            return Ok(equipment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEquipment(Guid id)
        {
            var equipment = await _equipmentService.GetEquipmentByIdAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(EquipmentCreateDTO equipmentCreateDTO)
        {
            var createdEquipment = await _equipmentService.CreateEquipmentAsync(equipmentCreateDTO);
            return CreatedAtAction(nameof(GetEquipment), new { id = createdEquipment.Id }, createdEquipment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(Guid id, EquipmentUpdateDTO equipmentUpdateDTO)
        {
            var updatedEquipment = await _equipmentService.UpdateEquipmentAsync(id, equipmentUpdateDTO);

            if (updatedEquipment == null)
            {
                return NotFound();
            }

            return Ok(updatedEquipment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(Guid id)
        {
            await _equipmentService.DeleteEquipmentAsync(id);
            return NoContent();
        }
    }
}
