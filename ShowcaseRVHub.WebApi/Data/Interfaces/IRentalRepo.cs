using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRentalRepo
    {
        Task<bool> CreateRentalAsync(Rental rental);
        Task<IEnumerable<Rental>?> GetRentalsAsync();
        Task<Rental?> GetRentalByIdAsync(int id);
        Task<bool> UpdateRentalAsync(Rental user);
        Task<bool> DeleteRentalAsync(int id);
    }
}
