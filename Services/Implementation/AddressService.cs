using AutoMapper;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interface;
using static gFit.Context.DTOs.AddressDto;

namespace gFit.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;

        public AddressService(IMapper mapper, IAddressRepository addressRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
        }

        public async Task<IEnumerable<AddressReadDTO>> GetAllAddressesAsync()
        {
            var addresses = await _addressRepository.GetAllAddressesAsync();
            return _mapper.Map<IEnumerable<AddressReadDTO>>(addresses);
        }

        public async Task<AddressReadDTO> GetAddressByIdAsync(Guid id)
        {
            var address = await _addressRepository.GetAddressByIdAsync(id);
            return _mapper.Map<AddressReadDTO>(address);
        }

        public async Task<AddressReadDTO> CreateAddressAsync(AddressCreateDTO addressCreateDTO)
        {
            var address = _mapper.Map<Address>(addressCreateDTO);

            address.CreatedAt = DateTime.UtcNow;
            address.UpdatedAt = DateTime.UtcNow;

            var createdAddress = await _addressRepository.CreateAddressAsync(address);
            return _mapper.Map<AddressReadDTO>(createdAddress);
        }

        public async Task<AddressReadDTO> UpdateAddressAsync(Guid id, AddressUpdateDTO addressUpdateDTO)
        {
            var existingAddress = await _addressRepository.GetAddressByIdAsync(id);

            if (existingAddress == null)
            {

                throw new Exception("Address not found");
            }

            var updatedAddress = await _addressRepository.UpdateAddressAsync(id, existingAddress);
            return _mapper.Map<AddressReadDTO>(updatedAddress);
        }

        public async Task DeleteAddressAsync(Guid id)
        {
            var existingAddress = await _addressRepository.GetAddressByIdAsync(id);

            if (existingAddress == null)
            {
                return;
            }

            await _addressRepository.DeleteAddressAsync(id);
        }
    }
}
