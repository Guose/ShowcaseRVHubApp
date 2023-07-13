using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.XUnitTest
{
    public class RvAPITests
    {
        private readonly RVRepo rvAPIs = new(
            ShowcaseDbContextHelper.GetMockDb(nameof(RvAPITests)));

        [Fact]
        public async Task Can_GetAll_RVs()
        {
            IEnumerable<VehicleRv>? rvs = await rvAPIs.GetVehiclesAsync();
            Assert.NotNull(rvs);
        }

        [Fact]
        public async Task Can_Get_RV_By_ID()
        {
            VehicleRv? rv = await rvAPIs.GetVehicleByIdAsync(1);
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
            VehicleRv? rv = await rvAPIs.GetVehicleByIdAsync(2);

            if (rv == null)
                Assert.Fail();

            Assert.True(await rvAPIs.DeleteUserAsync(rv.Id));
        }
    }
}
