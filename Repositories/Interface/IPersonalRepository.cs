using gFit.Models;

namespace gFit.Repositories.Interface
{
    public interface IPersonalRepository
    {
        Task<IEnumerable<Personal>> GetAllPersonalsAsync();
        Task<Personal> GetPersonalByIdAsync(Guid id);
        Task<Personal> GetPersonalByEmailAsync(string email);
        Task<Personal> CreatePersonalAsync(Personal personal);
        Task<Personal> UpdatePersonalAsync(Guid id, Personal personal);
        Task DeletePersonalAsync(Guid id);
    }
}

