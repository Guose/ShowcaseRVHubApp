namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IUserEmailService
    {
        Task<bool> ResetPasswordAsync(string email);
        Task<bool> RetrieveUsernameAsync(string email);
    }
}
