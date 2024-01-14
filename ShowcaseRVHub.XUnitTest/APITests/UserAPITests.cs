using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.DTOs;
using System.Text.Json;

namespace ShowcaseRVHub.XUnitTest.APITests
{
    public class UserAPITests
    {
        private ShowcaseDbContext? _context;
        private readonly ShowcaseDbContextHelper _showcaseDbContextHelper;
        private readonly UserRepo? _repo;
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public UserAPITests()
        {
            _showcaseDbContextHelper = new ShowcaseDbContextHelper(nameof(UserAPITests));
            _httpClient = new HttpClient();
            _baseAddress = "http://localhost:5000";
            _url = $"{_baseAddress}/api/users";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        [Fact]
        public async Task Can_GetAll_Users()
        {
            var response = await _httpClient.GetAsync(_url);
            string content = await response.Content.ReadAsStringAsync();
            List<ShowcaseUserDto>? users = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<List<ShowcaseUserDto>>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(users);
        }

        [Fact]
        public async Task Can_Get_User_By_ID()
        {
            var response = await _httpClient.GetAsync(_url + "/" + Guid.Parse("CF3E94B7-4052-4585-86E8-B4EA68BA1BDF"));
            string content = await response.Content.ReadAsStringAsync();
            ShowcaseUserDto? user = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<ShowcaseUserDto>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(user);
        }

        [Fact]
        public async Task Can_Get_User_By_ID_FAIL()
        {
            var response = await _httpClient.GetAsync(_url + "/" + Guid.Parse("CF3E94B7-4052-4585-86E8-B4EA68BA1BDF"));
            string content = await response.Content.ReadAsStringAsync();
            ShowcaseUserDto? users = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<ShowcaseUserDto>(content, _jsonSerializerOptions)
                : null;

            Assert.NotEqual("CF3E94B7-4052-4585-86E8-B4EA68BA1", users?.Id.ToString());
        }
    }
}
