using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("/renters")]
    [ApiController]
    public class RenterController : ControllerBase
    {
        private readonly IRenterRepo _renterRepo;

        public RenterController(IRenterRepo renterRepo)
        {
            _renterRepo = renterRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShowcaseRenter>>> GetAllRenters()
        {
            var renters = await _renterRepo.GetRentersAsync();

            return Ok(renters.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowcaseRenter>> GetRenterById(int id)
        {
            ShowcaseRenter renter = await _renterRepo.GetRenterByIdAsync(id);

            if (renter == null)
                return NotFound(new { Message = $"Item with id {id} does not exist." });

            return Ok(renter);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental(ShowcaseRenter renter)
        {
            if (renter == null)
                return BadRequest(new { Message = $"Your request could not be made." });

            await _renterRepo.UpdateRenterAsync(renter);

            return Ok(renter);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRental(ShowcaseRenter updateRenter)
        {
            ShowcaseRenter renter = await _renterRepo.GetRenterByIdAsync(updateRenter.Id);
            if (renter == null)
                return NotFound(new { Message = $"Item with id {updateRenter.Id} does not exist." });

            await _renterRepo.UpdateRenterAsync(renter);

            return Ok(renter);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRentalPatch(int id, JsonPatchDocument<ShowcaseRenter> updateRenter)
        {
            ShowcaseRenter renterPatch = await _renterRepo.GetRenterByIdAsync(id);
            if (renterPatch == null)
                return NotFound(new { Message = $"Item with id {id} does not exist." });

            updateRenter.ApplyTo(renterPatch);
            await _renterRepo.UpdateRenterAsync(renterPatch);

            return Ok(renterPatch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRental(int id)
        {
            await _renterRepo.DeleteRenterAsync(id);

            return Ok();
        }
    }
}
