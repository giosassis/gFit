using Amazon;
using System;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace gFit.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private readonly RegionEndpoint _region = RegionEndpoint.USEast1; // Ajuste para a região correta

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var awsAccessKeyId = _configuration["AwsAccessKeyId"];
            var awsSecretKey = _configuration["AwsSecretKey"];
            var authorizedEmail = _configuration["AuthorizedEmail"];
            var sendRequest = new SendEmailRequest
            {
                Source = authorizedEmail,
                Destination = new Destination { ToAddresses = new List<string> { toEmail } },
                Message = new Message
                {
                    Subject = new Content(subject),
<<<<<<< HEAD
                    Body = new Body { Text = new Content(message) }
=======
                    Body = new Body
                    {
                        Html = new Content
                        {
                            Charset = "UTF-8",
                            Data = message // Aqui, atribua o conteúdo HTML ao atributo Data
                        }
                    }
>>>>>>> 7252bec (feat: send confirmation email service)
                }
            };

            using var client = new AmazonSimpleEmailServiceClient(awsAccessKeyId, awsSecretKey, _region);
            await client.SendEmailAsync(sendRequest);
        }
    }
}