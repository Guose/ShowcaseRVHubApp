using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IRVRepo _rvRepo;
        private readonly JsonSerializerSettings _jsonSettings;

        public VehicleController(IRVRepo rvRepo)
        {
            _rvRepo = rvRepo;
            _jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
        }

        [HttpGet]
        public async Task<ActionResult> GetVehicles()
        {
            IEnumerable<VehicleRv>? rvs = await _rvRepo.GetAllAsync();

            if (rvs == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(rvs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVehicleById(int id)
        {
            VehicleRv? rv = await _rvRepo.GetByIdAsync(id);

            return rv == null 
                ? NotFound(new { Message = $"RV with id {id} does not exist." }) 
                : Ok(rv);
        }

        [HttpGet("{id}/{userId}")]
        public async Task<ActionResult> GetVehicleWithRenterUserAndRentals(int id, Guid userId)
        {
            VehicleRVDto? rvWithRentalsAndUser = await _rvRepo.GetVehicleWithRentalUserAndRenterAsync(id, userId);

            return rvWithRentalsAndUser == null
                ? NotFound(new { Message = $"RV with id {id} does not exist." })
                : Ok(rvWithRentalsAndUser);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRV(VehicleRVDto rv, Guid userId)
        {
            return await _rvRepo.CreateVehicleRvAsync(rv, userId) 
                ? Ok(rv) 
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRV(int id, VehicleRVDto newRv)
        {
            VehicleRv? rv = await _rvRepo.GetByIdAsync(id);

            if (rv == null)
                return NotFound(new { Message = $"RV with id {id} does not exist." });

            return await _rvRepo.UpdateVehicleAsync(newRv)
                ? NoContent()
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRV(int id)
        {
            VehicleRv rv = await _rvRepo.GetByIdAsync(id);
            
            if (rv != null)
            {
                _rvRepo.Remove(rv);
                return NoContent();
            }                
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
