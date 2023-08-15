using gFit.Models;
using static gFit.Context.DTOs.AddressDto;

namespace gFit.Services.Interface
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressReadDTO>> GetAllAddressesAsync();
        Task<AddressReadDTO> GetAddressByIdAsync(Guid id);
        Task<AddressReadDTO> CreateAddressAsync(AddressCreateDTO addressDTO);
        Task<AddressReadDTO> UpdateAddressAsync(Guid id, AddressUpdateDTO addressDTO);
        Task DeleteAddressAsync(Guid id);
    }
}
