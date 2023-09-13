using ShowcaseRVHub.WebApi.Models;
using System.Text.Json;

namespace ShowcaseRVHub.XUnitTest
{
    public class RenterAPITests
    {
        private readonly RenterRepo renterAPIs = new(ShowcaseDbContextHelper.GetMockDb(nameof(RenterAPITests)));

        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RenterAPITests()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://localhost:80";
            _url = $"{_baseAddress}/api/renters/";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        [Fact]
        public async Task Can_GetAll_Renters()
        {
            var response = await _httpClient.GetAsync(_url);
            string content = await response.Content.ReadAsStringAsync();
            List<ShowcaseRenter>? renters = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<List<ShowcaseRenter>>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(renters);
        }

        [Fact]
        public async Task Can_Get_Renter_By_ID()
        {
            var response = await _httpClient.GetAsync(_url + -1);
            string content = await response.Content.ReadAsStringAsync();
            ShowcaseRenter? renter = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<ShowcaseRenter>(content, _jsonSerializerOptions)
                : null;

            Assert.Equal("John", renter?.Firstname);
        }

        [Fact]
        public async Task Can_Get_Renter_By_ID_FAIL()
        {
            var response = await _httpClient.GetAsync(_url + 2);
            string content = await response.Content.ReadAsStringAsync();
            ShowcaseRenter? renter = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<ShowcaseRenter>(content, _jsonSerializerOptions)
                : null;

            Assert.NotEqual(1, renter?.Id);
        }

        //[Fact]
        //public async Task Delete_Renter_By_ID()
        //{
        //    var response = await _httpClient.DeleteAsync(_url + -2);
        //    Assert.True(response.IsSuccessStatusCode);
        //}
    }
}
