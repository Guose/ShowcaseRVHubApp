using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRenterRepo
    {
        Task CreateUserAsync(ShowcaseRenter rental);
        Task<IEnumerable<ShowcaseRenter>> GetlRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task UpdateRentalAsync(ShowcaseRenter rental);
        Task DeleteRentalAsync(int id);
    }
}
