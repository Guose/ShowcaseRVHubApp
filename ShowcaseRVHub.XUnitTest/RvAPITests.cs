using ShowcaseRVHub.WebApi.Models;
using System.Text.Json;

namespace ShowcaseRVHub.XUnitTest
{
    public class RvAPITests
    {
        private readonly RVRepo rvAPIs = new(
            ShowcaseDbContextHelper.GetMockDb(nameof(RvAPITests)));

        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RvAPITests()
        {
            _httpClient = new HttpClient();
            _baseAddress = "http://localhost:80";
            _url = $"{_baseAddress}/api/vehicles/";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

        }

        [Fact]
        public async Task Can_GetAll_RVs()
        {
            var response = await _httpClient.GetAsync(_url);
            string content = await response.Content.ReadAsStringAsync();
            List<VehicleRv>? rvs = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<List<VehicleRv>>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(rvs);
        }

        [Fact]
        public async Task Can_Get_RV_By_ID()
        {
            var response = await _httpClient.GetAsync(_url + -2);
            string content = await response.Content.ReadAsStringAsync();
            VehicleRv? rv = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<VehicleRv>(content, _jsonSerializerOptions)
                : null;

            Assert.NotNull(rv);
        }

        [Fact]
        public async Task Can_Get_RV_By_ID_FAIL()
        {
            var response = await _httpClient.GetAsync(_url + 1);
            string content = await response.Content.ReadAsStringAsync();
            VehicleRv? rv = response.IsSuccessStatusCode
                ? JsonSerializer.Deserialize<VehicleRv>(content, _jsonSerializerOptions)
                : null;

            Assert.NotEqual(-1, rv?.Id);
        }

        [Fact]
        public async Task Delete_RV_By_ID()
        {
            VehicleRv? rv = await rvAPIs.GetVehicleByIdAsync(-2);

            if (rv == null)
                Assert.Fail();

            Assert.True(await rvAPIs.DeleteUserAsync(rv.Id));
        }

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
