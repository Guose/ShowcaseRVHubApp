using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> GetUserByEmailAsync(string email);
    }
}
