using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
namespace gFit.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly string _awsAccessKeyId = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
        private readonly string _awsSecretKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");
        private readonly string authorizedEmail = Environment.GetEnvironmentVariable("AuthorizedEmail");
        private readonly RegionEndpoint _region = RegionEndpoint.USEast1;

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var sendRequest = new SendEmailRequest
            {
                Source = authorizedEmail,
                Destination = new Destination { ToAddresses = new List<string> { toEmail } },
                Message = new Message
                {
                    Subject = new Content(subject),
                    Body = new Body { Text = new Content(message) }
                }
            };

            using var client = new AmazonSimpleEmailServiceClient(_awsAccessKeyId, _awsSecretKey, _region);
            await client.SendEmailAsync(sendRequest);
        }
    }
}
