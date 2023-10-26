using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ShowcaseRVHub.WebApi.Data.Interfaces;
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
        public async Task<ActionResult<IEnumerable<RvMaintenance>>> GetMaintenance()
        {
            IEnumerable<RvMaintenance> maintenances = await _maintenance.GetMaintenanceAsync();

            if (maintenances == null)
                return NotFound(new { Message = $"Your request could not be made." });

            return Ok(maintenances.Take(5));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RvMaintenance>> GetMaintenanceById(int id)
        {
            RvMaintenance maintenance = await _maintenance.GetMaintenanceByIdAsync(id);

            if (maintenance == null)
                return NotFound(new { Message = $"Departure with id {id} does not exist." });

            return Ok(maintenance);
        }

        [HttpPost]
        public async Task<ActionResult> CreateMaintenance(RvMaintenance newMaintenance)
        {
            if (await _maintenance.CreateMaintenanceAsync(newMaintenance))
                return CreatedAtRoute(nameof(CreateMaintenance), new { id = newMaintenance.Id }, newMaintenance);
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMaintenance(int id, [FromBody] RvMaintenance updateMaintenance)
        {
            RvMaintenance? main = await _maintenance.GetMaintenanceByIdAsync(id);

            if (main == null)
                return NotFound(new { Message = $"Rv Maintenance item with id {id} does not exist." });

            if (await _maintenance.UpdateMaintenanceAsync(updateMaintenance))
                return Ok(updateMaintenance);
            else
                return BadRequest(new { Message = "Your request could not be made." });
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMaintenancePatch(int id, [FromBody] JsonPatchDocument<RvMaintenance> updateMaintenance)
        {
            RvMaintenance? maintenancePatch = await _maintenance.GetMaintenanceByIdAsync(id);

            if (maintenancePatch == null)
                return NotFound(new { Message = $"Rv Maintenance item with id {id} does not exist." });

            updateMaintenance.ApplyTo(maintenancePatch);
            if (await _maintenance.UpdateMaintenanceAsync(maintenancePatch))
                return Ok(maintenancePatch);
            else
                return BadRequest(new { Message = "Your request could not be made." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMaintenance(int id)
        {
            if (await _maintenance.DeleteMaintenanceAsync(id))
                return NoContent();
            else
                return BadRequest(new { Message = $"Your request could not be made." });
        }
    }
}
