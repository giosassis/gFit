using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IPersonalRepository
    {
        Task<IEnumerable<Personal>> GetAllPersonalsAsync();
        Task<Personal> GetPersonalByIdAsync(Guid id);
        Task<Personal> GetPersonalByEmailAsync(string email);
<<<<<<< HEAD
=======
        Task<bool> CheckCrefExists(string cref);
        Task<bool> CheckEmailExists(string email);
>>>>>>> de58bf75660d62e8496836152c1eea71d4844232
        Task<Personal> CreatePersonalAsync(Personal personal);
        Task<Personal> UpdatePersonalAsync(Guid id, Personal personal);
        Task DeletePersonalAsync(Guid id);
    }
}

