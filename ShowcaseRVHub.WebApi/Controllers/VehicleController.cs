using Azure;
using LinqToDB.Tools;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IRVRepo _rvRepo;
        private readonly IRenterRepo _renterRepo;

        public VehicleController(IRVRepo rvRepo, IRenterRepo renterRepo)
        {
            _rvRepo = rvRepo;
            _renterRepo = renterRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleRv>>> GetVehiclesAsync()
        {
            var rvs = await _rvRepo.GetVehiclesAsync();

            return Ok(rvs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleRv>> GetVehicleByIdAsync(int id)
        {
            var rv = await _rvRepo.GetVehicleByIdAsync(id);

            return Ok(rv);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleRv>> CreateRVAsync(VehicleRv rv)
        {
            await _rvRepo.CreateVehicleRvAsync(rv);

            return Ok(rv);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRVAsync(VehicleRv newRv)
        {
            await _rvRepo.UpdateUserAsync(newRv);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRVAsync(int id)
        {
            await _rvRepo.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
