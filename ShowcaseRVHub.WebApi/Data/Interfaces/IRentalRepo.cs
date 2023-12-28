using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRentalRepo : IGenericRepository<Rental>
    {
        Task<IEnumerable<RentalDto>?> GetRentalsAsync();
        Task<RentalDto?> GetRentalByIdAsync(int id);
        Task<bool> UpdateRentalAsync(RentalDto user);
    }
}
