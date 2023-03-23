using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ShowcaseRVHub.WebApi.Models
{
    public class ShowcaseUserModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsRemembered { get; set; } = false;

        public ShowcaseUserModel()
        {
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = null;
        }
    }
}
