namespace ShowcaseRVHub.MAUI.Services
{
    public class RenterDataService : IRenterDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RenterDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5012" : "http://192.168.1.10:5012";
            _url = $"{_baseAddress}/api/renters";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }
        public async Task<bool> CreateRenterAsync(RenterModel renter)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize(renter, _jsonSerializerOptions);

                StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_url, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully created RENTER");
                else
                    Debug.WriteLine("---> Non Http 2xx response for CREATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTER Exception: {ex.Message}");
            }
            return true;
        }

        public async Task<bool> DeleteRenterAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                var response = await _httpClient.DeleteAsync($"{_url}/{id}");

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully deleted RENTERS");
                else
                    Debug.WriteLine("---> Non Http 2xx response for DELETE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTERS Exception: {ex.Message}");
            }
            return true;
        }

        public async Task<IEnumerable<RenterModel>> GetAllRentersAsync()
        {
            List<RenterModel> renters = new List<RenterModel>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return renters ?? null;
            }

            try
            {
                var response = await _httpClient.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    renters = JsonSerializer.Deserialize<List<RenterModel>>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTER Exception: {ex.Message}");
            }

            return renters;
        }

        public async Task<RenterModel> GetRenterByIdAsync(int id)
        {
            RenterModel renter = new RenterModel();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return renter;
            }

            try
            {
                var response = await _httpClient.GetAsync($"{_url}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    renter = JsonSerializer.Deserialize<RenterModel>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTER Exception: {ex.Message}");
            }

            return renter;
        }

        public async Task<bool> UpdateRenterAsync(RenterModel renter)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize(renter, _jsonSerializerOptions);
                StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_url}/{renter.Id}", content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully updated RENTER");
                else
                    Debug.WriteLine("---> Non Http 2xx response for UPDATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTER Exception: {ex.Message}");
            }
            return true;
        }
    }
}
