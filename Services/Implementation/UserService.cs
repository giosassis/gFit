using System.Text;
using AutoMapper;
using gFit.Models;
using gFit.Repositories.Interface;
using gFit.Services.Interfaces;
using System.Security.Cryptography;
using gFit.Validator;
using static gFit.Context.DTOs.UserDto;
using gFit.Context.DTOs;

namespace gFit.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserReadDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserReadDTO>>(users);
        }

        public async Task<UserReadDTO> GetUserByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserReadDTO>(user);
        }

        public async Task<UserReadDTO> CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            if (!IsValidEmail(userCreateDTO.Email))
            {
                throw new ArgumentException("Invalid email format");
            }

            if (!PasswordValidator.Validate(userCreateDTO.Password))
            {
                throw new ArgumentException("Password must meet security requirements.");
            }

            string hashedPassword = PasswordHasher(userCreateDTO.Password);

            var user = _mapper.Map<User>(userCreateDTO);
            user.Password = hashedPassword;

            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            var createdUser = await _userRepository.CreateUserAsync(user);
            return _mapper.Map<UserReadDTO>(createdUser);
        }

        public async Task<UserReadDTO> UpdateUserAsync(Guid id, UserUpdateDTO userUpdateDTO)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            var updatedUser = await _userRepository.UpdateUserAsync(id, existingUser);
            return _mapper.Map<UserReadDTO>(updatedUser);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                return;
            }

            await _userRepository.DeleteUserAsync(id);
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static string PasswordHasher(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

    }
}
