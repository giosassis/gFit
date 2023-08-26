using static gFit.Context.DTOs.PersonalDto;

namespace gFit.Services.Interface
{
    public interface IPersonalService
    {
        Task<IEnumerable<PersonalReadDTO>> GetAllPersonalsAsync();
        Task<PersonalReadDTO> GetPersonalByIdAsync(Guid id);
        Task<PersonalReadDTO> GetPersonalByEmailAsync(string email);
        Task<PersonalReadDTO> CreatePersonalAsync(PersonalCreateDTO personalCreateDTO);
        Task<PersonalReadDTO> UpdatePersonalAsync(Guid id, PersonalUpdateDTO personalUpdateDTO);
        Task DeletePersonalAsync(Guid id);
    }
}

