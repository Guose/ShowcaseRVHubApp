namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IRenterDataService
    {
        Task<IEnumerable<RenterModel>> GetAllRentersAsync();
        Task<RenterModel> GetRenterByIdAsync(int id);
        Task<bool> CreateRenterAsync(RenterModel renter);
        Task<bool> UpdateRenterAsync(RenterModel renter);
        Task<bool> DeleteRenterAsync(int id);
    }
}
