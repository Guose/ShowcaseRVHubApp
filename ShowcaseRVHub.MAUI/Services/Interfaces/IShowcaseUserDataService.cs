using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IShowcaseUserDataService
    {
        Task<IQueryable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(Guid id);
    }
}
