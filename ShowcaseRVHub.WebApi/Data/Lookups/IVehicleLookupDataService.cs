using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public interface IVehicleLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetVehicleLookupAsync();
    }
}