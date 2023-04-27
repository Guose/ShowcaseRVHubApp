using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IUserRepo
    {
        Task CreateUserAsync(ShowcaseUser user);
        Task<IEnumerable<ShowcaseUser>> GetUsersAsync();
        Task<ShowcaseUser> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(ShowcaseUser user);
        Task DeleteUserAsync(Guid id);
    }
}
