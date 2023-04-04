using ShowcaseRVHub.Email.Models;
using System.Diagnostics;
using System.Text.Json;

namespace ShowcaseRVHub.Email.Services
{
    public class ShowcaseUserDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ShowcaseUserDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://localhost:5012";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<ShowcaseEmailUser> GetUserByIdAsync(Guid id)
        {
            ShowcaseEmailUser? user = new ShowcaseEmailUser();

            try
            {
                var response = await _httpClient.GetAsync($"{_url}/user/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    user = JsonSerializer.Deserialize<ShowcaseEmailUser>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
            }

            return user!;
        }

        public async Task<IQueryable<ShowcaseEmailUser>> GetAllUsersAsync()
        {
            List<ShowcaseEmailUser>? users = new List<ShowcaseEmailUser>();
            try
            {
                var response = await _httpClient.GetAsync($"{_url}/users");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonSerializer.Deserialize<List<ShowcaseEmailUser>>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
            }

            return users!.AsQueryable();
        }

    }
}
