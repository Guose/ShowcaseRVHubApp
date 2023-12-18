using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IUserRepo
    {        
        Task<IEnumerable<ShowcaseUserDto>?> GetUsersAsync();
        Task<ShowcaseUserDto?> GetUserByIdAsync(Guid id);
        Task<bool> CreateUserAsync(ShowcaseUserDto user);
        Task<bool> UpdateUserAsync(ShowcaseUserDto user);
        Task<bool> UpdateUsersPasswordAsync(Guid userId, ShowcaseUserDto user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
