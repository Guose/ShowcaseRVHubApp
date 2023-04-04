namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface ISendGridEmailService
    {
        Task SendResetPasswordEmailAsync(string toEmail, string firstName, string dynamicKey, string dynamicValue);
    }
}
