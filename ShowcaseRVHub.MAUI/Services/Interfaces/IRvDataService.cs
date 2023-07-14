namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IRvDataService
    {
        Task<List<RVModel>> GetAllRVsAsync();
        Task<RVModel> GetRvByIdAsync(int id);
        Task<bool> CreateRvAsync(RVModel model);
        Task<bool> UpdateRvAsync(RVModel model);
        Task<bool> DeleteRvAsync(int id);
    }
}
