namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string username, string password);
    }
}
