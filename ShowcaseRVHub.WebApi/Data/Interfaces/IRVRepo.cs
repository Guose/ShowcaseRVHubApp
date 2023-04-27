using ShowcaseRVHub.WebApi.Models;
using ShowcaseRVHub.WebApi.Models.DTO;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRVRepo
    {
        Task CreateVehicleRvAsync(VehicleRV rv);
        Task<IEnumerable<VehicleRV>> GetVehiclesAsync();
        Task<VehicleRV> GetVehicleByIdAsync(int id);
        Task UpdateUserAsync(VehicleRvDTO rv);
        Task DeleteUserAsync(int id);
    }
}
