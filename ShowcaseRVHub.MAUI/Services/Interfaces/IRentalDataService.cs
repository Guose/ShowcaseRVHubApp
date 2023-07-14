namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IRentalDataService
    {
        Task<IEnumerable<RentalModel>> GetAllRentalsAsync();
        Task<RentalModel> GetRentalByIdAsync(int id);
        Task<bool> CreateRentalAsync(RentalModel rental);
        Task<bool> UpdateRentalAsync(RentalModel rental);
        Task<bool> DeleteRentalAsync(int id);
    }
}
