using System;
using gFit.Services.Interface;
using Mustache;

namespace gFit.Services.Implementation
{
	public class EmailConfirmationService : IEmailConfirmationService
	{
        private readonly IEmailService _emailService;

        public EmailConfirmationService(IEmailService emailService)
        {
            _emailService = emailService;
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
