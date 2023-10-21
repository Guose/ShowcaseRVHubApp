using System.Text;
using ShowcaseRVHub.MAUI.Helpers;

namespace ShowcaseRVHub.MAUI.Services
{
    public class UserEmailService : IUserEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly IUserDataServiceHelper _userRepository;
        public UserEmailService(IUserDataServiceHelper userRepository)
        {
            _userRepository = userRepository;
            _httpClient = new HttpClient();
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:6000" : "http://localhost:6000";
            _url = $"{_baseAddress}/email";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
            };
        }

        public async Task<bool> ResetPasswordAsync(string email)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("---> No internet access...");
                return false;
            }
            try
            {
                UserModel user = await _userRepository.GetUserByEmailAsync(email);

                if (user != null)
                {
                    string jsonUser = JsonSerializer.Serialize(user, _jsonSerializerOptions);
                    StringContent content = new(jsonUser, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PutAsync(_url, content);

                    if (response.IsSuccessStatusCode)
                        Debug.WriteLine("Successfully sent user reset password email");
                    else
                        Debug.WriteLine("---> Non Http 2xx response for CREATE api");

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"---> Exception: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RetrieveUsernameAsync(string email)
        {
            UserModel user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                // Simulate returning the user's username
                return true;
            }

            return false;
        }
    }
}
