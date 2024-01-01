using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IArrivalRepo : IGenericRepository<Arrival>
    {
        Task<IEnumerable<ArrivalDto>?> GetArrivalsAsync();
        Task<ArrivalDto?> GetArrivalByIdAsync(int id);
        Task<bool> UpdateArrivalAsync(ArrivalDto arrival);
    }
}
