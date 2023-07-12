using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IUserRepo
    {
        Task<bool> CreateUserAsync(ShowcaseUser user);
        Task<IEnumerable<ShowcaseUser>?> GetUsersAsync();
        Task<ShowcaseUser?> GetUserByIdAsync(Guid id);
        Task<bool> UpdateUserAsync(ShowcaseUser user);
        Task<bool> UpdateUsersPasswordAsync(Guid userId, ShowcaseUser user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
