using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
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
        public async Task<ActionResult<IEnumerable<ShowcaseRenter>>> GetRenters()
        {
            IEnumerable<ShowcaseRenter>? renters = await _renterRepo.GetRentersAsync();

            if (renters == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(renters.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowcaseRenter>> GetRenterById(int id)
        {
            ShowcaseRenter? renter = await _renterRepo.GetRenterByIdAsync(id);

            if (renter == null)
                return NotFound(new { Message = $"Item with id {id} does not exist." });

            return Ok(renter);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental(ShowcaseRenter renter)
        {
            if (await _renterRepo.CreateRenterAsync(renter))
                return Ok(renter);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRental(int id, ShowcaseRenter updateRenter)
        {
            if (await _renterRepo.UpdateRenterAsync(updateRenter))
                return Ok(updateRenter);
            else
                return NotFound(new { Message = $"Renter with id {id} does not exist." });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRentalPatch(int id, JsonPatchDocument<ShowcaseRenter> updateRenter)
        {
            ShowcaseRenter? renterPatch = await _renterRepo.GetRenterByIdAsync(id);

            if (renterPatch == null)
                return NotFound(new { Message = $"Renter with id {id} does not exist." });

            updateRenter.ApplyTo(renterPatch);
            if (await _renterRepo.UpdateRenterAsync(renterPatch))
                return Ok(renterPatch);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRental(int id)
        {
            if (await _renterRepo.DeleteRenterAsync(id))
                return NoContent();
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
