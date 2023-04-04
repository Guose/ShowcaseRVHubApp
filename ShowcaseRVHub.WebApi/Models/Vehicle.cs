using ShowcaseRVHub.WebApi.Models.EnumTypes;
using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class Vehicle
    {
        [Key] public int Id { get; set; }
        [Required] public string Make { get; set; } = string.Empty;
        [Required]  public string Model { get; set; } = string.Empty;
        [Required] public string Year { get; set; } = string.Empty;
        [Required] public int Length { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        [Required] public double Odometer { get; set; }
        [Required] public int GeneratorHours { get; set; }
        [Required] public FuelLevelType FuelLevel { get; set; }
        [Required] public string ExteriorDamage { get; set; } = string.Empty;
        [Required] public string InteriorDamage { get; set; } = string.Empty;
        public string? Notes { get; set; }
        [Required] public int UserId { get; set; }
        public ShowcaseUser User { get; set; } = new ShowcaseUser();
    }
}
