using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRenterRepo : IGenericRepository<ShowcaseRenter>
    {
        Task<IEnumerable<ShowcaseRenterDto>?> GetRentersAsync();
        Task<ShowcaseRenterDto?> GetRenterByIdAsync(int id);
        Task<bool> UpdateRenterAsync(ShowcaseRenter renter);
    }
}
