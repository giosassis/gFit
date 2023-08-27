using System.Text;
using gFit.Context.DTOs;
using gFit.Models;
using System.Security.Cryptography;
using gFit.Repositories.Interface;
using gFit.Services.Interface;

using gFit.Utils;

namespace gFit.Services.Implementation
{
	public class AuthService : IAuthService
	{
        private readonly IPersonalService _personalService;
        private readonly IPersonalRepository _personalRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IPersonalService personalService, IJwtService jwtService, IPersonalRepository personalRepository)
        {
            _personalService = personalService;
            _jwtService = jwtService;
            _personalRepository = personalRepository;
        }

        public async Task<AuthResult> LoginAsync(LoginDto loginDTO)
        {
            var personal = await _personalRepository.GetPersonalByEmailAsync(loginDTO.Email);

            if (personal == null)
            {
                return new AuthResult { Success = false, Message = "User not found." };
            }

            if (!personal.IsEmailConfirmed)
            {
                return new AuthResult { Success = false, Message = "Email not confirmed yet." };
            }

            if (!PasswordMatches(personal, loginDTO.Password))
            {
                return new AuthResult { Success = false, Message = "Invalid credentials." };
            }

            string token = _jwtService.GenerateEmailConfirmationToken(personal.Email);
            return new AuthResult { Success = true, Message = "Login successful.", Token = token };
        }

        private static string PasswordHasher(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        private bool PasswordMatches(Personal personal, string enteredPassword)
        {
            string hashedEnteredPassword = PasswordHasher(enteredPassword);
            return hashedEnteredPassword == personal.Password;
        }

    }


}

