using gFit.Models;
using static gFit.Context.DTOs.UserDto;

namespace gFit.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDTO>> GetAllUsersAsync();
        Task<UserReadDTO> GetUserByIdAsync(Guid id);
        Task<UserReadDTO> CreateUserAsync(UserCreateDTO userCreateDTO);
        Task<UserReadDTO> UpdateUserAsync(Guid id, UserUpdateDTO userUpdateDTO);
        Task DeleteUserAsync(Guid id);
    }
}