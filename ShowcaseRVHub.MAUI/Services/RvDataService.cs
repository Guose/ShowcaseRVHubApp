

namespace ShowcaseRVHub.MAUI.Services
{
    public class RvDataService : IRvDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RvDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5012" : "http://192.168.1.10:5012";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        public async Task<List<RVModel>> GetAllRVsAsync()
        {
            List<RVModel> rvModels = new List<RVModel>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return rvModels ?? null;
            }

            try
            {
                var response = await _httpClient.GetAsync($"{_url}/vehicles");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    rvModels = JsonSerializer.Deserialize<List<RVModel>>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RV Exception: {ex.Message}");
            }

            //// Offline
            //using var stream = await FileSystem.OpenAppPackageFileAsync("rvdata.json");
            //using var reader = new StreamReader(stream);
            //var contents = await reader.ReadToEndAsync();
            //rvModels = JsonSerializer.Deserialize<List<RVModel>>(contents);

            return rvModels;
        }

        public async Task<RVModel> GetRvByIdAsync(int id)
        {
            RVModel rv = new RVModel();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return rv;
            }

            try
            {
                var response = await _httpClient.GetAsync($"{_url}/vehicles/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    rv = JsonSerializer.Deserialize<RVModel>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RV Exception: {ex.Message}");
            }

            return rv;
        }

        public async Task<bool> CreateRvAsync(RVModel rvModel)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize(rvModel, _jsonSerializerOptions);

                StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_url}/vehicles", content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully created RV");
                else
                    Debug.WriteLine("---> Non Http 2xx response for CREATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RV Exception: {ex.Message}");
            }
            return true;
        }

        public async Task<bool> UpdateRvAsync(RVModel rvModel)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize(rvModel, _jsonSerializerOptions);
                StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_url}/vehicles/{rvModel.Id}", content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully updated RV");
                else
                    Debug.WriteLine("---> Non Http 2xx response for UPDATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RV Exception: {ex.Message}");
            }
            return true;
        }

        public async Task<bool> DeleteRvAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                var response = await _httpClient.DeleteAsync($"{_url}/vehicles/{id}");

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully deleted RV");
                else
                    Debug.WriteLine("---> Non Http 2xx response for DELETE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RV Exception: {ex.Message}");
            }
            return true;
        }
    }
}
