using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/departures")]
    [ApiController]
    public class DepartureController : ControllerBase
    {
        private readonly IDepartureRepo _departureRepo;

        public DepartureController(IDepartureRepo departureRepo)
        {
            _departureRepo = departureRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departure>>> GetDepartures()
        {
            IEnumerable<Departure>? departures = await _departureRepo.GetDeparturesAsync();

            if (departures == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(departures.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departure>> GetDepartureById(int id)
        {
            Departure? departure = await _departureRepo.GetDepartureByIdAsync(id);

            if (departure == null)
                return NotFound(new { Message = $"Departure with id {id} does not exist." });

            return Ok(departure);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDeparture(Departure newDeparture)
        {
            if (await _departureRepo.CreateDepartureAsync(newDeparture))
                return CreatedAtRoute(nameof(CreateDeparture), new { id = newDeparture.Id }, newDeparture);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeparture(int id, [FromBody] Departure newDeparture)
        {
            Departure? departure = await _departureRepo.GetDepartureByIdAsync(id);

            if (departure == null)
                return NotFound(new { Message = $"Departure with id {id} does not exist." });

            if (await _departureRepo.CreateDepartureAsync(newDeparture))
                return Ok(departure);
            else
                return BadRequest(new { Message = "Your request could not be made." } );
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateDeparturePatch(int id, [FromBody] JsonPatchDocument<Departure> updateDeparture)
        {
            Departure? departurePatch = await _departureRepo.GetDepartureByIdAsync(id);

            if (departurePatch == null)
                return NotFound(new { Message = $"Departure with  id {id} does not exist." });
            
            updateDeparture.ApplyTo(departurePatch);
            if (await _departureRepo.UpdateDepartureAsync(departurePatch))
                return Ok(departurePatch);
            else
                return BadRequest(new { Message = "Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeparture(int id)
        {
            if (await _departureRepo.DeleteDepartureAsync(id))
                return NoContent();
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
