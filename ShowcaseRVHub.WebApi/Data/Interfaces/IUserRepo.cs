using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IUserRepo : IGenericRepository<ShowcaseUser>
    {
        Task<IEnumerable<ShowcaseUserDto>?> GetAllUsersAsync();
        Task<IEnumerable<ShowcaseUserDto>> GetUsersWithVehicles();
        Task<ShowcaseUserDto?> GetUserByIdAsync(Guid id);
        Task<bool> UpdateUserAsync(ShowcaseUserDto user);
        Task<bool> UpdateUsersPasswordAsync(Guid userId, ShowcaseUserDto user);
    }
}
