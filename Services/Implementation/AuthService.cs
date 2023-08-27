using System.Text;
using gFit.Context.DTOs;
using gFit.Models;
using System.Security.Cryptography;
using gFit.Repositories.Interface;
using gFit.Services.Interface;
using gFit.Validator;
using gFit.Utils;
using Mustache;

namespace gFit.Services.Implementation
{
	public class AuthService : IAuthService
	{
        private readonly IConfiguration _configuration;
        private readonly IPersonalService _personalService;
        private readonly IPersonalRepository _personalRepository;
        private readonly IJwtService _jwtService;

        public AuthService(IPersonalService personalService, IJwtService jwtService, IPersonalRepository personalRepository, IConfiguration configuration)
        {
            _personalService = personalService;
            _jwtService = jwtService;
            _personalRepository = personalRepository;
            _configuration = configuration;
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

        public async Task<AuthResult> RequestPasswordResetAsync(EmailDto emailDto)
        {
            var personal = await _personalRepository.GetPersonalByEmailAsync(emailDto.Email);

            if (personal == null)
            {
                return new AuthResult { Success = false, Message = "User not found." };
            }

            var resetToken = _jwtService.GeneratePasswordResetToken(personal.Email);
            var resetLink = $"http://localhost:3000/redefinir-senha/{resetToken}";

            string templatePath = "Utils/EmailTemplate";
            string templateFileName = "PasswordResetEmailTemplate.html";
            string fullPath = Path.Combine(templatePath, templateFileName);
            string templateContent = File.ReadAllText(fullPath);

            var emailMessage = new FormatCompiler().Compile(templateContent).Render(new
            {
                PersonalName = personal.Name,
                ResetLink = resetLink
            });

            try
            {
                var emailService = new EmailService(_configuration);
                await emailService.SendEmailAsync(personal.Email, "Password Reset Request", emailMessage);

                return new AuthResult { Success = true, Message = "Password reset link has been sent to your email." };
            }
            catch (Exception ex)
            {
                return new AuthResult { Success = false, Message = "An error occurred while sending the password reset email." };
            }
        }

        public async Task<AuthResult> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var personal = await _personalRepository.GetPersonalByEmailAsync(resetPasswordDto.Email);

            if (personal == null)
            {
                return new AuthResult { Success = false, Message = "User not found." };
            }

            var isValidToken = _jwtService.ValidatePasswordResetToken(resetPasswordDto.Token);

            if (!isValidToken)
            {
                return new AuthResult { Success = false, Message = "Invalid reset token." };
            }

            if (!PasswordValidator.Validate(resetPasswordDto.NewPassword))
            {
                return new AuthResult { Success = false, Message = "New password does not meet the required criteria." };
            }

            var hashedPassword = PasswordHasher(resetPasswordDto.NewPassword);
            personal.Password = hashedPassword;

            await _personalRepository.UpdatePersonalAsync(personal.Id, personal);

            return new AuthResult { Success = true, Message = "Password reset successfully." };
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
