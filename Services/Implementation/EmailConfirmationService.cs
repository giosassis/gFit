using gFit.Services.Interface;
using Mustache;
using System.Diagnostics;
using System.IO;
using static gFit.Context.DTOs.PersonalDto;

namespace gFit.Services.Implementation
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly IPersonalService _personalService;
        private readonly IEmailService _emailService;
        private readonly JwtService _jwtService;

        public EmailConfirmationService(IPersonalService personalService, IEmailService emailService, JwtService jwtService)
        {
            _personalService = personalService;
            _emailService = emailService;
            _jwtService = jwtService;
        }

        public async Task<bool> VerifyEmailTokenAsync(string email, string token)
        {
            Console.WriteLine("ConfirmEmailAsync method called.");
            var personal = await _personalService.GetPersonalByEmailAsync(email);
            if (personal == null || personal.IsEmailConfirmed)
            {
                return false;
            }

            Console.WriteLine($"Stored Token: {personal.EmailConfirmationToken}");
            Console.WriteLine($"Received Token: {token}");

            return string.Equals(personal.EmailConfirmationToken.Trim(), token.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        public async Task<bool> ConfirmEmailAsync(string email, string token)
        {
            try
            {
                Console.WriteLine("ConfirmEmailAsync method called.");
                var personal = await _personalService.GetPersonalByEmailAsync(email);

                if (personal == null || personal.IsEmailConfirmed || !string.Equals(personal.EmailConfirmationToken, token, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Confirmation failed due to invalid token or already confirmed email.");
                    return false;
                }

                personal.IsEmailConfirmed = true;
                personal.EmailConfirmationToken = null;

                var updatedPersonal = await _personalService.UpdatePersonalAsync(personal.Id, new PersonalUpdateDTO
                {
                    Name = personal.Name,
                    Email = personal.Email,
                    IsEmailConfirmed = true,
                    EmailConfirmationToken = null,
                    Description = personal.Description,
                    UpdatedAt = DateTime.UtcNow
                });

                Console.Write(updatedPersonal);

                return updatedPersonal != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in ConfirmEmailAsync: " + ex.Message);
                // Handle exception, log error, etc.
                return false;
            }
        }

        public async Task SendConfirmationEmailAsync(string email, string confirmationLink, string personalName)
        {
            var subject = "Bem-vindo ao nosso serviço!";
            string templatePath = "Utils/EmailTemplate";
            string templateFileName = "ConfirmationEmailTemplate.html";
            string fullPath = Path.Combine(templatePath, templateFileName);
            string templateContent = File.ReadAllText(fullPath);

            var emailMessage = new FormatCompiler().Compile(templateContent).Render(new
            {
                PersonalName = personalName,
                ConfirmationLink = confirmationLink
            });


            await _emailService.SendEmailAsync(email, subject, emailMessage);
        }
    }
}
