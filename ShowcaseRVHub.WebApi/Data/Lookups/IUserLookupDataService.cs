using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public interface IUserLookupDataService
    {
        Task<IEnumerable<LookupItem>> GetUserLookupAsync();
    }
}