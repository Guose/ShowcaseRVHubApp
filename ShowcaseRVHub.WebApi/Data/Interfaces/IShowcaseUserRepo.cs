using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IShowcaseUserRepo
    {
        Task CreateUserAsync(ShowcaseUser user);
        Task<IEnumerable<ShowcaseUser>> GetUsersAsync();
        Task<ShowcaseUser> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(Guid id, ShowcaseUser user);
        Task DeleteUserAsync(Guid id);
    }
}
