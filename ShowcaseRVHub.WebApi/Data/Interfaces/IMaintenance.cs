using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IMaintenance : IGenericRepository<RvMaintenance>
    {
        Task<IEnumerable<RvMaintenanceDto>?> GetMaintenanceAsync();
        Task<RvMaintenanceDto?> GetMaintenanceByIdAsync(int id);
        Task<bool> UpdateMaintenanceAsync(RvMaintenanceDto rvMaintenance);
    }
}
