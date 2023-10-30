using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IDepartureRepo
    {
        Task<bool> CreateDepartureAsync(Departure departure);
        Task<IEnumerable<Departure>?> GetDeparturesAsync();
        Task<Departure?> GetDepartureByIdAsync(int id);
        Task<bool> UpdateDepartureAsync(Departure departure);
        Task<bool> DeleteDepartureAsync(int id);
    }
}
