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

            if (renters == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(renters.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShowcaseRenterDto>> GetRenterById(int id)
        {
            ShowcaseRenterDto? renter = await _renterRepo.GetRenterByIdAsync(id);

            if (renter == null)
                return NotFound(new { Message = $"Item with id {id} does not exist." });

            return Ok(renter);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental(ShowcaseRenter renter)
        {
            return await _renterRepo.AddAsync(renter)
            ? Ok(renter)
            : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRental(int id, ShowcaseRenterDto updateRenter)
        {
            if (await _renterRepo.UpdateRenterAsync(updateRenter))
                return Ok(updateRenter);
            else
                return NotFound(new { Message = $"Renter with id {id} does not exist." });
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
        public ActionResult DeleteRental(ShowcaseRenter renter)
        {
            if (renter != null)
            {
                _renterRepo.Remove(renter);
                return NoContent();
            }
                
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
