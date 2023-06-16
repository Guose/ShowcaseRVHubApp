using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRVRepo
    {
        Task CreateVehicleRvAsync(VehicleRv rv);
        Task<IEnumerable<VehicleRv>> GetVehiclesAsync();
        Task<VehicleRv> GetVehicleByIdAsync(int id);
        Task UpdateUserAsync(VehicleRv rv);
        Task DeleteUserAsync(int id);
    }
}
