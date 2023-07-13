using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IUserRepo
    {        
        Task<IEnumerable<ShowcaseUser>?> GetUsersAsync();
        Task<ShowcaseUser?> GetUserByIdAsync(Guid id);
        Task<ShowcaseUser?> GetUserVehicleRVs(Guid id);
        Task<ShowcaseUser?> GetUserRentals(Guid id);

        Task<bool> CreateUserAsync(ShowcaseUser user);
        Task<bool> UpdateUserAsync(ShowcaseUser user);
        Task<bool> UpdateUsersPasswordAsync(Guid userId, ShowcaseUser user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
