using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
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
        public async Task<ActionResult<IEnumerable<DepartureDto>>> GetDepartures()
        {
            IEnumerable<DepartureDto>? departures = await _departureRepo.GetDeparturesAsync();

            if (departures == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(departures.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Departure>> GetDepartureById(int id)
        {
            DepartureDto? departure = await _departureRepo.GetDepartureByIdAsync(id);

            if (departure == null)
                return NotFound(new { Message = $"Departure with id {id} does not exist." });

            return Ok(departure);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDeparture(Departure newDeparture)
        {
            return await _departureRepo.AddAsync(newDeparture)
            ? CreatedAtRoute(nameof(CreateDeparture), new { id = newDeparture.Id }, newDeparture)
            : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDeparture(int id, [FromBody] DepartureDto newDeparture)
        {
            DepartureDto? departure = await _departureRepo.GetDepartureByIdAsync(id);

            if (departure == null)
                return NotFound(new { Message = $"Departure with id {id} does not exist." });
            
            return await _departureRepo.UpdateDepartureAsync(newDeparture)
            ? Ok(departure)
            : BadRequest(new { Message = "Your request could not be made." } );
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateDeparturePatch(int id, [FromBody] JsonPatchDocument<DepartureDto> updateDeparture)
        {
            DepartureDto? departurePatch = await _departureRepo.GetDepartureByIdAsync(id);

            if (departurePatch == null)
                return NotFound(new { Message = $"Departure with  id {id} does not exist." });
            
            updateDeparture.ApplyTo(departurePatch);

            return await _departureRepo.UpdateDepartureAsync(departurePatch)
            ? Ok(departurePatch)
            : BadRequest(new { Message = "Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteDeparture(Departure departure)
        {
            if (departure != null)
            {
                _departureRepo.Remove(departure);
                return NoContent();
            }
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
