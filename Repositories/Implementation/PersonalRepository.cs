using gFit.Context;
using gFit.Models;
using gFit.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace gFit.Repositories.Implementation
{
    public class PersonalRepository : IPersonalRepository
    {
        private readonly DataContext _context;

        public PersonalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Personal>> GetAllPersonalsAsync()
        {
            return await _context.Personal.ToListAsync();
        }

        public async Task<Personal> GetPersonalByIdAsync(Guid id)
        {
            return await _context.Personal.FindAsync(id);
        }

        public async Task<Personal> GetPersonalByEmailAsync(string email)
        {
            return await _context.Personal.FirstOrDefaultAsync(p => p.Email == email);
        }

<<<<<<< HEAD
=======
        public async Task<bool> CheckCrefExists(string cref)
        {
            return await _context.Personal.AnyAsync(p => p.Cref == cref);
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            return await _context.Personal.AnyAsync(p => p.Email == email);
        }

>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
        public async Task<Personal> CreatePersonalAsync(Personal personal)
        {
            _context.Personal.Add(personal);
            await _context.SaveChangesAsync();
            return personal;
        }

        public async Task<Personal> UpdatePersonalAsync(Guid id, Personal personal)
        {
            var existingPersonal = await _context.Personal.FindAsync(id);

            if (existingPersonal == null)
            {
                return null;
            }

            existingPersonal.Name = personal.Name;
            existingPersonal.Email = personal.Email;
            existingPersonal.Password = personal.Password;
<<<<<<< HEAD
            existingPersonal.EmailConfirmationToken = null;
=======
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
            existingPersonal.IsEmailConfirmed = true;

            existingPersonal.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingPersonal;
        }

        public async Task DeletePersonalAsync(Guid id)
        {
            var personal = await _context.Personal.FindAsync(id);

            if (personal != null)
            {
                _context.Personal.Remove(personal);
                await _context.SaveChangesAsync();
            }
        }
    }
}
