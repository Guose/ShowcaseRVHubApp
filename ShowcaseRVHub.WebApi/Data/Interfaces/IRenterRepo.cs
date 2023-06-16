using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRenterRepo
    {
        Task CreateUserAsync(Rental rental);
        Task<IEnumerable<Rental>> GetlRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }
}
