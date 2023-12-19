using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public interface IRenterLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetRenterLookupAsync();
    }
}