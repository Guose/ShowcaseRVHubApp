using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRVRepo : IGenericRepository<VehicleRv>
    {
        Task<bool> CreateVehicleRvAsync(VehicleRVDto rv, Guid userId);
        Task<VehicleRVDto?> GetVehicleWithRentalUserAndRenterAsync(int id, Guid userId);
        Task<bool> UpdateVehicleAsync(VehicleRVDto rv);
    }
}
