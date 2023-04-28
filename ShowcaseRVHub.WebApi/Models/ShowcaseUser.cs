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
        public bool IsRemembered { get; set; } = false;

        public List<VehicleRV> Vehicles { get; set; }

        public ShowcaseUser()
        {
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = null;
            Vehicles = new List<VehicleRV>();
        }
    }
}
