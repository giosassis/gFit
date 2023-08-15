using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using gFit.Context.DTOs;


namespace gFit.Repositories.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _context.Address.ToListAsync();
        }

        public async Task<Address> GetAddressByIdAsync(Guid id)
        {
            return await _context.Address.FindAsync(id);
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<Address> UpdateAddressAsync(Guid id, Address address)
        {
            var existingAddress = await _context.Address.FindAsync(id);

            if (existingAddress == null)
            {
                return null;
            }

            existingAddress.Street = address.Street;
            existingAddress.City = address.City;
            existingAddress.State = address.State;
            existingAddress.PostalCode = address.PostalCode;
            existingAddress.HouseNumber = address.HouseNumber;
            existingAddress.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingAddress;
        }

        public async Task DeleteAddressAsync(Guid id)
        {
            var address = await _context.Address.FindAsync(id);

            if (address != null)
            {
                _context.Address.Remove(address);
                await _context.SaveChangesAsync();
            }
        }
    }
}
