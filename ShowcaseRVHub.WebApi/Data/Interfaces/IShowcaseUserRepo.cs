using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IShowcaseUserRepo
    {
        Task CreateUserAsync(ShowcaseUserModel user);
        Task<IEnumerable<ShowcaseUserModel>> GetUsersAsync();
        Task<ShowcaseUserModel> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(Guid id, ShowcaseUserModel user);
        Task DeleteUserAsync(Guid id);
    }
}
