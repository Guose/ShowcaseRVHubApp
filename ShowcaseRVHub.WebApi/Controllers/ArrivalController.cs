using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/arrivals")]
    [ApiController]
    public class ArrivalController : ControllerBase
    {
        private readonly IArrivalRepo _arrivalRepo;

        public ArrivalController(IArrivalRepo arrivalRepo)
        {
            _arrivalRepo = arrivalRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Arrival>>> GetArrivals()
        {
            IEnumerable<Arrival> arrivals = await _arrivalRepo.GetArrivalsAsync();

            if (arrivals == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(arrivals.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Arrival>> GetArrivalById(int id)
        {
            Arrival arrival = await _arrivalRepo.GetArrivalByIdAsync(id);

            if (arrival == null)
                return NotFound(new { Message = $"Arrival with id {id} does not exist." });

            return Ok(arrival);
        }

        [HttpPost]
        public async Task<ActionResult> CreateArrival([FromBody]Arrival newArrival)
        {
            if (await _arrivalRepo.CreateArrivalAsync(newArrival))
                return CreatedAtRoute(nameof(CreateArrival), new { id = newArrival.Id }, newArrival);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArrival(int id, [FromBody] Arrival updateArrival)
        {
            Arrival? arrival = await _arrivalRepo.GetArrivalByIdAsync(id);

            if (arrival == null)
                return NotFound(new { Message = $"Arrival with id {id} does not exist." });

            if (await _arrivalRepo.UpdateArrivalAsync(updateArrival))
                return Ok(updateArrival);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateArrivalPatch(int id, [FromBody] JsonPatchDocument<Arrival> updateArrival)
        {
            Arrival? arrivalPatch = await _arrivalRepo.GetArrivalByIdAsync(id);

            if (arrivalPatch == null)
                return NotFound(new { Message = $"Rental with id {id} does not exist." });

            updateArrival.ApplyTo(arrivalPatch);

            if (await _arrivalRepo.UpdateArrivalAsync(arrivalPatch)) 
                return Ok(arrivalPatch);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArrival(int id)
        {
            if (await _arrivalRepo.DeleteArrivalAsync(id))
                return NoContent();
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
