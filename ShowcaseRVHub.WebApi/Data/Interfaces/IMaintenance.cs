using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IMaintenance
    {
        Task<bool> CreateMaintenanceAsync(RvMaintenance rvMaintenance);
        Task<IEnumerable<RvMaintenance>?> GetMaintenanceAsync();
        Task<RvMaintenance?> GetMaintenanceByIdAsync(int id);
        Task<bool> UpdateMaintenanceAsync(RvMaintenance rvMaintenance);
        Task<bool> DeleteMaintenanceAsync(int id);
    }
}
