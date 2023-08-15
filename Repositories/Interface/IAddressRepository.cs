using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IAddressRepository 
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync();
        Task<Address> GetAddressByIdAsync(Guid id);
        Task<Address> CreateAddressAsync(Address adress);
        Task<Address> UpdateAddressAsync(Guid id, Address adress);
        Task DeleteAddressAsync(Guid id);
    }
}
