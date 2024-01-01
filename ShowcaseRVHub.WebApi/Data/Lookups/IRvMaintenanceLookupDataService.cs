using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public interface IRvMaintenanceLookupDataService
    {
        Task<List<LookupItem>> GetMaintenanceLookupAsync();
    }
}