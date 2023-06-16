using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRentalRepo
    {
        Task CreateRenterAsync(Rental rental);
        Task<IEnumerable<Rental>> GetRentersAsync();
        Task<Rental> GetRenterByIdAsync(int id);
        Task UpdateRenterAsync(Rental user);
        Task DeleteRenterAsync(int id);
    }
}
