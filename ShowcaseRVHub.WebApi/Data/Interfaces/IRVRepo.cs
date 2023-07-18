using Microsoft.AspNetCore.JsonPatch;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRVRepo
    {
        Task<bool> CreateVehicleRvAsync(VehicleRv rv);
        Task<IEnumerable<VehicleRv>?> GetVehiclesAsync();
        Task<VehicleRv?> GetVehicleWithRenterUserAndRentalsAsync(int id, Guid userId);
        Task<VehicleRv?> GetVehicleByIdAsync(int id);
        Task<bool> UpdateUserAsync(VehicleRv rv);
        Task<bool> DeleteUserAsync(int id);
    }
}
