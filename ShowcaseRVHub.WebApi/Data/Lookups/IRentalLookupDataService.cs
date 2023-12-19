using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public interface IRentalLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetRentalLookupAsync();
    }
}