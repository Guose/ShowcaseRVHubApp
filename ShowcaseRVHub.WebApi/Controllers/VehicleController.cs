using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;
using ShowcaseRVHub.WebApi.Models.DTO;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IRVRepo _rvRepo;

        public VehicleController(IRVRepo rvRepo)
        {
            _rvRepo = rvRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleRV>>> GetVehiclesAsync()
        {
            var rvs = await _rvRepo.GetVehiclesAsync();

            return Ok(rvs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleRV>> GetVehicleByIdAsync(int id)
        {
            var rv = await _rvRepo.GetVehicleByIdAsync(id);

            return Ok(rv);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleRV>> CreateRVAsync(VehicleRV rv)
        {
            await _rvRepo.CreateVehicleRvAsync(rv);

            return CreatedAtRoute(nameof(CreateRVAsync), new {id = rv.Id }, rv);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRVAsync(VehicleRvDTO rvDto)
        {
            await _rvRepo.UpdateUserAsync(rvDto);

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
