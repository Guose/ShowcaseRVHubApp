using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IDepartureRepo : IGenericRepository<Departure>
    {
        Task<IEnumerable<DepartureDto>?> GetDeparturesAsync();
        Task<DepartureDto?> GetDepartureByIdAsync(int id);
        Task<bool> UpdateDepartureAsync(DepartureDto departure);
    }
}
