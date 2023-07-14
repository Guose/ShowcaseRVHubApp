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
            _baseAddress = "http://192.168.1.10:5012";
            _url = $"{_baseAddress}/api/vehicles/";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
        }

        [Fact]
        public async Task Can_GetAll_RVs()
        {
            //IEnumerable<VehicleRv>? rvs = await rvAPIs.GetVehiclesAsync();
            List<VehicleRv>? rvs = new List<VehicleRv>();

            var response = await _httpClient.GetAsync(_url);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                rvs = JsonSerializer.Deserialize<List<VehicleRv>>(content, _jsonSerializerOptions);
            }

            Assert.NotNull(rvs);
        }

        [Fact]
        public async Task Can_Get_RV_By_ID()
        {
            VehicleRv? rv = await rvAPIs.GetVehicleByIdAsync(-1);
            Assert.NotNull(rv);
        }

        [Fact]
        public async Task Can_Get_RV_By_ID_FAIL()
        {
            VehicleRv? rv = await rvAPIs.GetVehicleByIdAsync(2);
            Assert.NotEqual(1, rv?.Id);
        }

        [Fact]
        public async Task Can_Delete_RV_By_ID()
        {
            VehicleRv? rv = await rvAPIs.GetVehicleByIdAsync(-2);

            if (rv == null)
                Assert.Fail();

            Assert.True(await rvAPIs.DeleteUserAsync(rv.Id));
        }

        [Fact]
        public async Task Can_Test_Relationship_Rental_To_RV()
        {
            VehicleRv? rv = await rvAPIs.GetVehicleByIdAsync(-2);

            if (rv == null || rv.Rentals == null)
                Assert.Fail();

            Assert.True(rv.Rentals?.Count > 0);
        }
    }
}
