using ShowcaseRVHub.WebApi.Data.Repositories;
using ShowcaseRVHub.WebApi.DTOs;

namespace ShowcaseRVHub.XUnitTest.RepositoryTests
{
    public class RvRepoTests
    {
        private readonly RVRepo? _rvRepo;
        public VehicleRVDto? Rv { get; set; }

        [Fact]
        public async Task Can_Get_All_RVs()
        {
            IEnumerable<VehicleRVDto>? rvs = await _rvRepo!.GetAllVehiclesAsync();
            Assert.NotNull(rvs);
        }

        [Fact]
        public async Task Can_Get_RV_By_Id()
        {
            Rv = await _rvRepo!.GetVehicleByIdAsync(-1);
            Assert.NotNull(Rv);
        }

        [Fact]
        public async Task Can_Get_RV_By_Id_FAIL_Model()
        {
            Rv = await _rvRepo!.GetVehicleByIdAsync(-2);
            Assert.NotEqual("Sunseeker", Rv!.Model);
        }
    }
}
