﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
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
        public async Task<ActionResult<IEnumerable<ArrivalDto>>> GetArrivals()
        {
            IEnumerable<ArrivalDto>? arrivals = await _arrivalRepo.GetArrivalsAsync();

            return arrivals != null
                ? Ok(arrivals.Take(5))
                : NotFound(new { Message = $"Your request could not be made." });            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArrivalDto>> GetArrivalById(int id)
        {
            ArrivalDto? arrival = await _arrivalRepo.GetArrivalByIdAsync(id);

            return arrival != null 
                ? Ok(arrival)
                : NotFound(new { Message = $"Arrival with id {id} does not exist." });
        }

        [HttpPost]
        public async Task<ActionResult> CreateArrival([FromBody]Arrival newArrival)
        {
            return await _arrivalRepo.CreateAsync(newArrival)
                ? CreatedAtRoute(nameof(CreateArrival), new { id = newArrival.Id }, newArrival)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArrival(int id, [FromBody] ArrivalDto updateArrival)
        {
            ArrivalDto? arrival = await _arrivalRepo.GetArrivalByIdAsync(id);

            if (arrival == null)
                return NotFound(new { Message = $"Arrival with id {id} does not exist." });

            return await _arrivalRepo.UpdateArrivalAsync(updateArrival)
                ? Ok(updateArrival)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateArrivalPatch(int id, [FromBody] JsonPatchDocument<ArrivalDto> updateArrival)
        {
            ArrivalDto? arrivalPatch = await _arrivalRepo.GetArrivalByIdAsync(id);

            if (arrivalPatch == null)
                return NotFound(new { Message = $"Rental with id {id} does not exist." });

            updateArrival.ApplyTo(arrivalPatch);

            return await _arrivalRepo.UpdateArrivalAsync(arrivalPatch)
                ? Ok(arrivalPatch)
                : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArrival(Arrival arrival)
        {
            return await _arrivalRepo.DeleteAsync(arrival)
                ? NoContent()
                : BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
