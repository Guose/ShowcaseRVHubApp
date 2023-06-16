using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRenterRepo
    {
        Task CreateRenterAsync(ShowcaseRenter renter);
        Task<IEnumerable<ShowcaseRenter>> GetRentersAsync();
        Task<ShowcaseRenter> GetRenterByIdAsync(int id);
        Task UpdateRenterAsync(ShowcaseRenter renter);
        Task DeleteRenterAsync(int id);
    }
}
