using Microsoft.AspNetCore.Mvc;
using gFit.Services.Interface;
using static gFit.Context.DTOs.AddressDto;

namespace gFit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTrainingSeries()
        {
            var address = await _addressService.GetAllAddressesAsync();
            return Ok(address);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var address = await _addressService.GetAddressByIdAsync(id);

            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(AddressCreateDTO addressCreateDTO)
        {
            var createdAddress = await _addressService.CreateAddressAsync(addressCreateDTO);
            return CreatedAtAction(nameof(GetAddress), new { id = createdAddress.Id }, createdAddress);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(Guid id, AddressUpdateDTO addressUpdateDTO)
        {
            var updatedAddress = await _addressService.UpdateAddressAsync(id, addressUpdateDTO);

            if (updatedAddress == null)
            {
                return NotFound();
            }

            return Ok(updatedAddress);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(Guid id)
        {
            await _addressService.DeleteAddressAsync(id);
            return NoContent();
        }
    }
}
