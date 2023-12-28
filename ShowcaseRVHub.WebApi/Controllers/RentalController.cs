using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public partial class RentalController : ControllerBase
    {
        private readonly IRentalRepo _rentalRepo;

        public RentalController(IRentalRepo rentalRepo)
        {
            _rentalRepo = rentalRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            IEnumerable<RentalDto>? rentals = await _rentalRepo.GetRentalsAsync();

            if (rentals == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(rentals?.Take(5));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRentalById(int id)
        {
            RentalDto? rental = await _rentalRepo.GetRentalByIdAsync(id);

            if (rental == null)
                return NotFound(new { Message = $"Rental with id {id} does not exist." } );

            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental([FromBody] Rental rental)
        {
            return await _rentalRepo.AddAsync(rental)
            ? CreatedAtRoute(nameof(CreateRental), new {id = rental.Id}, rental)
            : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRental(int id, [FromBody] RentalDto updateRental)
        {
            RentalDto? rental = await _rentalRepo.GetRentalByIdAsync(id);

            if (rental == null)
                return NotFound(new { Message = $"Rental with id {id} does not exist." });

            if (await _rentalRepo.UpdateRentalAsync(updateRental))
                return Ok(updateRental);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRentalPatch(int id, [FromBody] JsonPatchDocument<RentalDto> updateRental)
        {
            RentalDto? rentalPatch = await _rentalRepo.GetRentalByIdAsync(id);

            if (rentalPatch == null)
                return NotFound(new { Message = $"Rental with id {id} does not exist." } );

            updateRental.ApplyTo(rentalPatch);
            if (await _rentalRepo.UpdateRentalAsync(rentalPatch))
                return Ok(rentalPatch);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRental(Rental rental)
        {
            if (rental != null)
            {
                _rentalRepo.Remove(rental);
                return NoContent();
            }
                
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
