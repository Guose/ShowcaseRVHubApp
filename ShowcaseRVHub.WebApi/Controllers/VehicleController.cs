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

        public VehicleController(IRVRepo rvRepo)
        {
            _rvRepo = rvRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleRv>>> GetVehicles()
        {
            IEnumerable<VehicleRv>? rvs = await _rvRepo.GetVehiclesAsync();

            if (rvs == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(rvs.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleRv>> GetVehicleById(int id)
        {
            VehicleRv? rv = await _rvRepo.GetVehicleByIdAsync(id);

            if (rv == null)
                return NotFound(new { Message = $"RV with id {id} does not exist." });

            return Ok(rv);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleRv>> CreateRV(VehicleRv rv)
        {
            if (await _rvRepo.CreateVehicleRvAsync(rv))
                return Ok(rv);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRV(int id, VehicleRv newRv)
        {
            VehicleRv? rv = await _rvRepo.GetVehicleByIdAsync(id);

            if (rv == null)
                return NotFound(new { Message = $"RV with id {id} does not exist." });

            if (await _rvRepo.UpdateUserAsync(newRv))
                return NoContent();
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRV(int id)
        {
            if (await _rvRepo.DeleteUserAsync(id))
                return NoContent();
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
