using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Models.EnumTypes;
using ShowcaseRVHub.WebApi.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public async Task<ActionResult> ChangeUserPassord(EmailRequest user)
        {
            EmailRequest req = new EmailRequest(user.Email, EmailTemplateIds.ResetPassword, "first_name", user.FirstName);

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("justin@showcasemi.com", "Showcase RV HUB");
            var to = new EmailAddress(user.Email, user.FirstName);
            var data = req.TemplateData;
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, req.TemplateId, data);
            var response = await client.SendEmailAsync(msg);

            if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                throw new Exception($"Faild to send email. Staus Code: {response.StatusCode}");

            return Ok(response);
        }
    }
}
