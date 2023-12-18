using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRVRepo
    {
        Task<bool> CreateVehicleRvAsync(VehicleRVDto rv, Guid userId);
        Task<IEnumerable<VehicleRVDto>?> GetVehiclesAsync();
        Task<VehicleRv?> GetVehicleWithRentalUserAndRenterAsync(int id, Guid userId);
        Task<VehicleRVDto?> GetVehicleByIdAsync(int id);
        Task<bool> UpdateUserAsync(VehicleRVDto rv);
        Task<bool> DeleteUserAsync(int id);
    }
}
