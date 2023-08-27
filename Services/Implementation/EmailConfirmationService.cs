using Mustache;
using gFit.Services.Interface;

namespace gFit.Services.Implementation
{
    public class EmailConfirmationService : IEmailConfirmationService
    {
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public EmailConfirmationService(IEmailService emailService, IConfiguration configuration)
        {
            _emailService = emailService;
            _configuration = configuration;
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

            try
            {
                await _emailService.SendEmailAsync(email, subject, emailMessage);
            }
            catch (Exception ex)
            {
                // Lidar com erros no envio de email, se necessário
                Console.WriteLine($"Erro ao enviar email de confirmação para {email}: {ex.Message}");
            }
        }
    }
}
