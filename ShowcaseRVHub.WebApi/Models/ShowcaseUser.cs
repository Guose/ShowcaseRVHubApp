using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class ShowcaseUser
    {
        [Key] public Guid Id { get; set; }
        [Required] public string Email { get; set; } = string.Empty;
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        [Required] public string Username { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Required] public bool IsRemembered { get; set; } = false;

        [JsonIgnore] public ICollection<Arrival>? Arrivals { get; set; }
        [JsonIgnore] public ICollection<Departure>? Departures { get; set; }
        [JsonIgnore] public ICollection<VehicleRv>? Vehicles { get; set; }
        [JsonIgnore] public ICollection<RvMaintenance>? RvMaintenances { get; set; }

        public ShowcaseUser()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = null;
        }
    }
}
