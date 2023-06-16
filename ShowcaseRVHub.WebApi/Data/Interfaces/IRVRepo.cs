using ShowcaseRVHub.WebApi.Models;
using ShowcaseRVHub.WebApi.Models.DTO;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRVRepo
    {
        Task CreateVehicleRvAsync(VehicleRv rv);
        Task<IEnumerable<VehicleRv>> GetVehiclesAsync();
        Task<VehicleRv> GetVehicleByIdAsync(int id);
        Task UpdateUserAsync(VehicleRvDTO rv);
        Task DeleteUserAsync(int id);
    }
}
