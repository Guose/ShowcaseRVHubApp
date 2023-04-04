using EmailTest.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

internal class Program
{
    private static void Main(string[] args)
    {
        User user = new User
        {
            Email = "justinelder2017@gmail.com",
            FirstName = "Justin",
            LastName = "Elder"
        };
        Email.ExecuteTwoAsync(user, "d-de9998d9cf8049ff8e8722b38e71149e").Wait();
    }
    
}

internal static class Email
{
    public static async Task ExecuteTwoAsync(User user, string templateId)
    {
        var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        var client = new SendGridClient(apiKey);
        var from = new EmailAddress("justin@showcasemi.com", "Showcase RV HUB");
        var to = new EmailAddress(user.Email, user.FirstName);
        var data = new Dictionary<string, string> { { "first_name", user.FirstName } };
        var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, data);
        var response = await client.SendEmailAsync(msg);

        if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
        {
            throw new Exception($"Faild to send email. Staus Code: {response.StatusCode}");
        }
    }
}