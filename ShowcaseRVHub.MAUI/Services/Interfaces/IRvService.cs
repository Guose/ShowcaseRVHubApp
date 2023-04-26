using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IRvService
    {
        Task<List<RVModel>> GetRVsAsync();
    }
}
