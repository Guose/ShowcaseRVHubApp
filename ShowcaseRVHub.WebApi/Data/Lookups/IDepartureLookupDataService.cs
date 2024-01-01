using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public interface IDepartureLookupDataService
    {
        Task<List<LookupItem>> GetDepartureLookupAsync();
    }
}