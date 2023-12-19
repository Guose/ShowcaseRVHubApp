using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public interface IArrivalLookupDataService
    {
        Task<List<LookupItem>> GetArrivalLookupAsync();
    }
}