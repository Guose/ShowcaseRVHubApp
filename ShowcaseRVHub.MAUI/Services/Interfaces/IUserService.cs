namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> ResetPasswordAsync(string email);
        Task<bool> RetrieveUsernameAsync(string email);
    }
}
