using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;

namespace ShowcaseRVHub.MAUI.Services
{
    public class RVService : IRvService
    {
        HttpClient _httpClient;
        public RVService()
        {
            _httpClient = new HttpClient();
        }

        List<RVModel> rvModels;

        public async Task<List<RVModel>> GetRVsAsync()
        {
            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("rvdata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            rvModels = JsonSerializer.Deserialize<List<RVModel>>(contents);

            return rvModels;
        }
    }
}
