using ShowcaseRVHub.MAUI.Model;
using ShowcaseRVHub.MAUI.Services.Interfaces;
using System.Text;

namespace ShowcaseRVHub.MAUI.Services
{
    public class ShowcaseUserDataService : IShowcaseUserDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ShowcaseUserDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5012" : "http://localhost:5012";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task CreateUserAsync(UserModel user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize(user, _jsonSerializerOptions);
                StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_url}/users", content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully created user");
                else
                    Debug.WriteLine("---> Non Http 2xx response for CREATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
            }
            return;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                var response = await _httpClient.DeleteAsync($"{_url}/users/{id}");

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully deleted user");
                else
                    Debug.WriteLine("---> Non Http 2xx response for DELETE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
            }
            return;
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            UserModel user = new UserModel();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return user;
            }

            try
            {
                var response = await _httpClient.GetAsync($"{_url}/user/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    user = JsonSerializer.Deserialize<UserModel>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
            }

            return user;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            List<UserModel> users = new List<UserModel>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return users;
            }

            try
            {
                var response = await _httpClient.GetAsync($"{_url}/users");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    users = JsonSerializer.Deserialize<List<UserModel>>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
            }

            return users;
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize(user, _jsonSerializerOptions);
                StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_url}/users/{user.Id}", content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully updated user");
                else
                    Debug.WriteLine("---> Non Http 2xx response for UPDATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
            }
            return;
        }
    }
}
