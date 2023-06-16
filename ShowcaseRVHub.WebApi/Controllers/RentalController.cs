using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Data.Repositories;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("/rental")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepo _rentalRepo;
        public RentalController(IRentalRepo rentalRepo)
        {
            _rentalRepo = rentalRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            var rentals = await _rentalRepo.GetRentalsAsync();

            return Ok(rentals.Take(5));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRentalById(int id)
        {
            Rental rental = await _rentalRepo.GetRentalByIdAsync(id);

            if (rental == null)
                return NotFound(new { Message = $"Item with id {id} does not exist." });

            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRental(Rental rental)
        {
            if (rental == null)
                return BadRequest(new { Message = $"Your request could not be made." });

            await _rentalRepo.UpdateRentalAsync(rental);

            return Ok(rental);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRental(Rental updateRental)
        {
            Rental rental = await _rentalRepo.GetRentalByIdAsync(updateRental.Id);
            if (rental == null)
                return NotFound(new { Message = $"Item with id {updateRental.Id} does not exist." });

            await _rentalRepo.UpdateRentalAsync(rental);

            return Ok(rental);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateRentalPatch(int id, JsonPatchDocument<Rental> updateRental)
        {
            Rental rentalPatch = await _rentalRepo.GetRentalByIdAsync(id);
            if (rentalPatch == null)
                return NotFound(new { Message = $"Item with id {id} does not exist." });

            updateRental.ApplyTo(rentalPatch);
            await _rentalRepo.UpdateRentalAsync(rentalPatch);

            return Ok(rentalPatch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRental(int id)
        {
            await _rentalRepo.DeleteRentalAsync(id);

            return Ok();
        }
    }
}
