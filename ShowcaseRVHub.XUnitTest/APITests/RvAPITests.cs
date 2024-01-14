using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.DTOs;
using System.Text.Json;

namespace ShowcaseRVHub.XUnitTest.APITests
{
    public class RvAPITests
    {
        private ShowcaseDbContext? _context;
        private readonly ShowcaseDbContextHelper _showcaseDbContextHelper;
        private readonly RVRepo? _repo;
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RvAPITests()
        {
            _showcaseDbContextHelper = new ShowcaseDbContextHelper(nameof(RvAPITests));
            _httpClient = new HttpClient();
            _baseAddress = "http://localhost:5000";
            _url = $"{_baseAddress}/api/vehicles";

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
        public async Task Can_GetAll_RVs()
        {
            var response = await _httpClient.GetAsync(_url);
            string content = await response.Content.ReadAsStringAsync();
            List<VehicleRVDto>? rvs = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<List<VehicleRVDto>>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(rvs);
        }

        [Fact]
        public async Task Can_Get_RV_By_ID()
        {
            var response = await _httpClient.GetAsync(_url + "/" + -2);
            string content = await response.Content.ReadAsStringAsync();
            VehicleRVDto? rv = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<VehicleRVDto>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(rv);
        }

        [Fact]
        public async Task Can_Get_RV_By_ID_FAIL()
        {
            var response = await _httpClient.GetAsync(_url + "/" + -1);
            string content = await response.Content.ReadAsStringAsync();
            VehicleRVDto? rv = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<VehicleRVDto>(content, _jsonSerializerOptions)
                : null;

            Assert.NotEqual(1, rv?.Id);
        }

        //[Fact]
        //public async Task Delete_RV_By_ID()
        //{
        //    VehicleRVDto? rv = await _repo!.GetVehicleByIdAsync(-2);

        //    if (rv == null)
        //        Assert.Fail();

        //    // TODO: Add generic repository "Remove()" method
        //    // Assert.True(await rvAPIs.DeleteUserAsync(rv.Id));
        //}

        //[Fact]
        //public async Task Can_Test_Relationship_Rental_To_RV()
        //{
        //    var response = await _httpClient.GetAsync(_url + -1);
        //    string content = await response.Content.ReadAsStringAsync();
        //    VehicleRv? rv = response.IsSuccessStatusCode
        //        ? JsonSerializer.Deserialize<VehicleRv>(content, _jsonSerializerOptions)
        //        : null;

        //    if (rv == null || rv.Rentals == null)
        //        Assert.Fail();

        //    Assert.True(rv.Rentals?.Count > 0);
        //}

        //[Fact]
        //public async Task Can_Test_Relationship_RentalAndUser_To_RV()
        //{
        //    var response = await _httpClient.GetAsync(_url + -1);
        //    string content = await response.Content.ReadAsStringAsync();
        //    VehicleRv? rv = response.IsSuccessStatusCode
        //        ? JsonSerializer.Deserialize<VehicleRv>(content, _jsonSerializerOptions)
        //        : null;

        //    if (rv == null || rv.Rentals == null || rv.User == null)
        //        Assert.Fail();

        //    Assert.True(rv.Rentals?.Count > 0);
        //}
    }
}
