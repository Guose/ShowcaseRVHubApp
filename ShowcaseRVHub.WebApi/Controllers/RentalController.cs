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

            return rentals != null
                ? Ok(rentals?.Take(5))
                : NotFound(new { Message = $"Your request could not be made." });            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRentalById(int id)
        {
            RentalDto? rental = await _rentalRepo.GetRentalByIdAsync(id);

            return rental != null
                ? Ok(rental)
                : NotFound(new { Message = $"Rental with id {id} does not exist." } );            
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental([FromBody] Rental rental)
        {
            return await _rentalRepo.CreateAsync(rental)
                ? CreatedAtRoute(nameof(CreateRental), new {id = rental.Id}, rental)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRental(int id, [FromBody] RentalDto updateRental)
        {
            RentalDto? rental = await _rentalRepo.GetRentalByIdAsync(id);

            if (rental == null)
                return NotFound(new { Message = $"Rental with id {id} does not exist." });

            return await _rentalRepo.UpdateRentalAsync(updateRental)
                ? Ok(updateRental)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRentalPatch(int id, [FromBody] JsonPatchDocument<RentalDto> updateRental)
        {
            RentalDto? rentalPatch = await _rentalRepo.GetRentalByIdAsync(id);

            if (rentalPatch == null)
                return NotFound(new { Message = $"Rental with id {id} does not exist." } );

            updateRental.ApplyTo(rentalPatch);
            return await _rentalRepo.UpdateRentalAsync(rentalPatch)
                ? Ok(rentalPatch)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRental(Rental rental)
        {
            return await _rentalRepo.DeleteAsync(rental)
                ? NoContent()
                : BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
