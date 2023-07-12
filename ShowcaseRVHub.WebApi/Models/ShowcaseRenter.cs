using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class ShowcaseRenter
    {
        [Key] public int Id { get; set; }
        [Required] public string Firstname { get; set; } = string.Empty;
        [Required] public string Lastname { get; set; } = string.Empty;
        [Required] public string Email { get; set; } = string.Empty;
        [Required] public string Phone { get; set; } = string.Empty;
        public List<VehicleRv>? Vehicles { get; set; }
    }
}
