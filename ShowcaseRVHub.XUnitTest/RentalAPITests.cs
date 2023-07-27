using ShowcaseRVHub.WebApi.Models;
using System.Text.Json;

namespace ShowcaseRVHub.XUnitTest
{
    public class RentalAPITests
    {
        private readonly RentalRepo rentalAPIs = new(ShowcaseDbContextHelper.GetMockDb(nameof(RentalAPITests)));

        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RentalAPITests()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://192.168.1.10:5012";
            _url = $"{_baseAddress}/api/rentals/";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        [Fact]
        public async Task Can_GetAll_Rentals()
        {
            List<Rental>? rentals = new List<Rental>();

            var response = await _httpClient.GetAsync(_url);
            string content = await response.Content.ReadAsStringAsync();
            rentals = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<List<Rental>>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(rentals);
        }

        [Fact]
        public async Task Can_Get_Rental_By_ID()
        {
            Rental? rental = new Rental();

            var response = await _httpClient.GetAsync(_url + -1);
            string content = await response.Content.ReadAsStringAsync();
            rental = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<Rental>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(rental);
        }

        [Fact]
        public async Task Can_Get_Rental_By_ID_FAIL()
        {
            Rental? rental = new Rental();

            var response = await _httpClient.GetAsync(_url + 1);
            string content = await response.Content.ReadAsStringAsync();
            rental = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<Rental>(content, _jsonSerializerOptions)
                : null;

            Assert.Null(rental);
        }

        //[Fact]
        //public async Task Delete_Rental_By_ID()
        //{
        //    var response = await _httpClient.DeleteAsync(_url + -2);
        //    Assert.True(response.IsSuccessStatusCode);
        //}
    }
}
