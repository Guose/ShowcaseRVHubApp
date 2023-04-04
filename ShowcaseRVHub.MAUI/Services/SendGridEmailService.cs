using SendGrid;
using SendGrid.Helpers.Mail;
using ShowcaseRVHub.MAUI.Services.Interfaces;
using System.Net.Http.Headers;

namespace ShowcaseRVHub.MAUI.Services
{
    public class SendGridEmailService : ISendGridEmailService
    {
        private readonly string _templateId;
        public SendGridEmailService(string templateId)
        {
            _templateId = templateId;
        }

        public async Task SendResetPasswordEmailAsync(string toEmail, string firstName, string dynamicKey, string dynamicValue)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("justin@showcasemi.com", "Showcase RV HUB");
            var to = new EmailAddress(toEmail, firstName);
            var data = new Dictionary<string, string> { { dynamicKey, dynamicValue } };
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, _templateId, data);
            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
            {
                throw new Exception($"Faild to send email. Staus Code: {response.StatusCode}");
            }
        }
    }
}
