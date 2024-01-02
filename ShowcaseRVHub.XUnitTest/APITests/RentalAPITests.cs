using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Models;
using System.Text.Json;

namespace ShowcaseRVHub.XUnitTest.APITests
{
    public class RentalAPITests
    {
        private ShowcaseDbContext? _context;
        private readonly ShowcaseDbContextHelper _showcaseDbContextHelper;
        private RentalRepo? _repo;
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RentalAPITests()
        {
            _showcaseDbContextHelper = new ShowcaseDbContextHelper(nameof(RentalAPITests));
            _httpClient = new HttpClient();
            _baseAddress = "http://localhost:5000";
            _url = $"{_baseAddress}/api/rentals/";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        private async Task<ShowcaseDbContext> GetData()
        {
            _context = await _showcaseDbContextHelper.GetMockDbAsync();
            return _context;
        }

        [Fact]
        public async Task Add_New_Rental()
        {
            using (_context = await _showcaseDbContextHelper.GetMockDbAsync())
            {
                _repo = new RentalRepo(_context);
            }
        }

        [Fact]
        public async Task Can_GetAll_Rentals()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(_url);
            string content = await response.Content.ReadAsStringAsync();
            List<Rental>? rentals = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<List<Rental>>(content, _jsonSerializerOptions)
                : null;

            Assert.NotEmpty(rentals!);
        }

        [Fact]
        public async Task Can_Get_Rental_By_Id()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(_url + -1);
            string content = await response.Content.ReadAsStringAsync();
            Rental? rental = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<Rental>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(rental);
        }

        [Fact]
        public async Task Can_Get_Rental_By_ID_FAIL()
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(_url + 1);
            string content = await response.Content.ReadAsStringAsync();
            Rental? rental = response.IsSuccessStatusCode
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
