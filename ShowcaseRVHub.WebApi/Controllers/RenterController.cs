using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/renters")]
    [ApiController]
    public class RenterController : ControllerBase
    {
        private readonly IRenterRepo _renterRepo;

        public RenterController(IRenterRepo renterRepo)
        {
            _renterRepo = renterRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowcaseRenterDto>>> GetRenters()
        {
            IEnumerable<ShowcaseRenterDto>? renters = await _renterRepo.GetRentersAsync();

            return renters != null
                ? Ok(renters.Take(5))
                : NotFound(new { Message = $"Your request could not be made." });            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowcaseRenterDto>> GetRenterById(int id)
        {
            ShowcaseRenterDto? renter = await _renterRepo.GetRenterByIdAsync(id);

            return renter != null
                ? Ok(renter)
                : NotFound(new { Message = $"Item with id {id} does not exist." });            
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental(ShowcaseRenter renter)
        {
            return await _renterRepo.CreateAsync(renter)
                ? Ok(renter)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRental(int id, ShowcaseRenterDto updateRenter)
        {
            return await _renterRepo.UpdateRenterAsync(updateRenter)
                ? Ok(updateRenter)
                : NotFound(new { Message = $"Renter with id {id} does not exist." });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRentalPatch(int id, JsonPatchDocument<ShowcaseRenterDto> updateRenter)
        {
            ShowcaseRenterDto? renterPatch = await _renterRepo.GetRenterByIdAsync(id);

            if (renterPatch == null)
                return NotFound(new { Message = $"Renter with id {id} does not exist." });

            updateRenter.ApplyTo(renterPatch);

            return await _renterRepo.UpdateRenterAsync(renterPatch)
                ? Ok(renterPatch)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRental(ShowcaseRenter renter)
        {
            return await _renterRepo.DeleteAsync(renter)
                ? NoContent()
                : BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
