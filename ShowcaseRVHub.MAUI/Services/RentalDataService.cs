﻿namespace ShowcaseRVHub.MAUI.Services
{
    public class RentalDataService : IRentalDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RentalDataService()
        {
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
            _url = $"{_baseAddress}/api/rentals";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };
        }
        public async Task<bool> CreateRentalAsync(RentalModel rental)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                string jsonRental = JsonSerializer.Serialize(rental, _jsonSerializerOptions);

                StringContent content = new(jsonRental, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_url, content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully created RENTAL");
                else
                    Debug.WriteLine("---> Non Http 2xx response for CREATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTAL Exception: {ex.Message}");
            }
            return true;
        }

        public async Task<bool> DeleteRentalAsync(int id)
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
                    Debug.WriteLine("Successfully deleted RENTAL");
                else
                    Debug.WriteLine("---> Non Http 2xx response for DELETE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTAL Exception: {ex.Message}");
            }
            return true;
        }

        public async Task<IEnumerable<RentalModel>> GetAllRentalsAsync()
        {
            List<RentalModel> rentals = new List<RentalModel>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return rentals ?? null;
            }

            try
            {
                var response = await _httpClient.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    rentals = JsonSerializer.Deserialize<List<RentalModel>>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTAL Exception: {ex.Message}");
            }

            return rentals;
        }

        public async Task<RentalModel> GetRentalByIdAsync(int id)
        {
            RentalModel rental = new RentalModel();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return rental;
            }

            try
            {
                var response = await _httpClient.GetAsync($"{_url}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    rental = JsonSerializer.Deserialize<RentalModel>(content, _jsonSerializerOptions);
                }
                else
                    Debug.WriteLine("---> Non Http 2xx response for READ api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTAL Exception: {ex.Message}");
            }

            return rental;
        }

        public async Task<bool> UpdateRentalAsync(RentalModel rental)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }

            try
            {
                string jsonUser = JsonSerializer.Serialize(rental, _jsonSerializerOptions);
                StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_url}/{rental.Id}", content);

                if (response.IsSuccessStatusCode)
                    Debug.WriteLine("Successfully updated RENTAL");
                else
                    Debug.WriteLine("---> Non Http 2xx response for UPDATE api");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> RENTAL Exception: {ex.Message}");
            }
            return true;
        }
    }
}
