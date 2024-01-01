using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRVRepo : IGenericRepository<VehicleRv>
    {
        Task<VehicleRVDto?> GetVehicleByIdAsync(int id);
        Task<IEnumerable<VehicleRVDto>?> GetAllVehiclesAsync();
        Task<VehicleRVDto?> GetVehicleWithRentalUserAndRenterAsync(int id, Guid userId);
        Task<bool> UpdateVehicleAsync(VehicleRVDto rv);
    }
}
