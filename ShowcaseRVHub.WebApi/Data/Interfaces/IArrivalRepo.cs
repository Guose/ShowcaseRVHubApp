using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IArrivalRepo
    {
        Task<bool> CreateArrivalAsync(Arrival arrival);
        Task<IEnumerable<Arrival>?> GetArrivalsAsync();
        Task<Arrival?> GetArrivalByIdAsync(int id);
        Task<bool> UpdateArrivalAsync(Arrival arrival);
        Task<bool> DeleteArrivalAsync(int id);
    }
}
