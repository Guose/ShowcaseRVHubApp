using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Controllers
{
    [Route("api/maintenance")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenance _maintenance;

        public MaintenanceController(IMaintenance maintenance)
        {
            _maintenance = maintenance;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RvMaintenanceDto>>> GetMaintenance()
        {
            IEnumerable<RvMaintenanceDto>? maintenances = await _maintenance.GetMaintenanceAsync();

            if (maintenances == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(maintenances.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RvMaintenanceDto>> GetMaintenanceById(int id)
        {
            RvMaintenanceDto? maintenance = await _maintenance.GetMaintenanceByIdAsync(id);

            if (maintenance == null)
                return NotFound(new { Message = $"Departure with id {id} does not exist." });

            return Ok(maintenance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaintenance(RvMaintenance newMaintenance)
        {
            return await _maintenance.AddAsync(newMaintenance)
            ? CreatedAtRoute(nameof(CreateMaintenance), new { id = newMaintenance.Id }, newMaintenance)
            : BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenance(int id, [FromBody] RvMaintenanceDto updateMaintenance)
        {
            RvMaintenanceDto? main = await _maintenance.GetMaintenanceByIdAsync(id);

            if (main == null)
                return NotFound(new { Message = $"Rv Maintenance item with id {id} does not exist." });

            return await _maintenance.UpdateMaintenanceAsync(updateMaintenance)
            ? Ok(main)
            : BadRequest(new { Message = "Your request could not be made." });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMaintenancePatch(int id, [FromBody] JsonPatchDocument<RvMaintenanceDto> updateMaintenance)
        {
            RvMaintenanceDto? maintenancePatch = await _maintenance.GetMaintenanceByIdAsync(id);

            if (maintenancePatch == null)
                return NotFound(new { Message = $"Rv Maintenance item with id {id} does not exist." });

            updateMaintenance.ApplyTo(maintenancePatch);

            return await _maintenance.UpdateMaintenanceAsync(maintenancePatch)
            ? Ok(maintenancePatch)
            : BadRequest(new { Message = "Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMaintenance(RvMaintenance maintenance)
        {
            if (maintenance != null)
            {
                _maintenance.Remove(maintenance);
                return NoContent();
            }
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
