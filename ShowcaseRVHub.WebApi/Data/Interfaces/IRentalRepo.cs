using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRentalRepo
    {
        Task CreateRentalAsync(Rental rental);
        Task<IEnumerable<Rental>> GetRentalsAsync();
        Task<Rental> GetRentalByIdAsync(int id);
        Task UpdateRentalAsync(Rental user);
        Task DeleteRentalAsync(int id);
    }
}
