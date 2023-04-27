using LinqToDB.Mapping;
using ShowcaseRVHub.WebApi.Models.EnumTypes;
using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class VehicleRV
    {
        [Key] public int Id { get; set; }
        [Required] public string Make { get; set; } = string.Empty;
        [Required]  public string Model { get; set; } = string.Empty;
        [Required] public string Year { get; set; } = string.Empty;
        [Nullable] public string Chassis { get; set; } = string.Empty;
        [Required] public RVClassType Class { get; set; }
        [Required] public int Sleeps { get; set; }
        [Nullable] public int Length { get; set; }
        [Nullable] public double Height { get; set; }
        [Nullable] public string Image { get; set; } = string.Empty;
        [Nullable] public string Description { get; set; } = string.Empty;
        [Required] public DateTime CreatedOn { get; set; }
        [Required] public DateTime ModifiedOn { get; set; }
        [Required] public double Odometer { get; set; }
        [Required] public int GeneratorHours { get; set; }
        [Required] public LevelType FuelLevel { get; set; }
        [Required] public BedType MasterBedType { get; set; }
        [Required] public bool IsBooked { get; set; }
        [Required] public bool HasSlideout { get; set; }
        [Required] public bool HasGenerator { get; set; }


        [Required] public Guid UserId { get; set; }
        public ShowcaseUser User { get; set; } = new ShowcaseUser();
    }
}
