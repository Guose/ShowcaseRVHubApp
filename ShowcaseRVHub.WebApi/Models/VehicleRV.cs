using LinqToDB.Mapping;
using ShowcaseRVHub.WebApi.Models.EnumTypes;
using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class VehicleRv
    {
        [Key] public int Id { get; set; }
        [Required] public string Make { get; set; } = string.Empty;
        [Required]  public string Model { get; set; } = string.Empty;
        [Nullable] public int Year { get; set; }
        [Nullable] public string Chassis { get; set; } = string.Empty;
        [Required] public RVClassType Class { get; set; }
        [Required] public int Sleeps { get; set; }
        [Nullable] public int Length { get; set; }
        [Nullable] public double Height { get; set; }
        [Nullable] public string Image { get; set; } = string.Empty;
        [Nullable] public string Description { get; set; } = string.Empty;
        [Required] public DateTime CreatedOn { get; set; } = DateTime.Now;
        [Nullable] public DateTime ModifiedOn { get; set; }
        [Required] public double Odometer { get; set; }
        [Required] public int GeneratorHours { get; set; }
        [Required] public LevelType FuelLevel { get; set; }
        [Required] public BedType MasterBedType { get; set; }
        [Nullable] public bool IsBooked { get; set; } = false;
        [Nullable] public bool HasSlideout { get; set; } = false;
        [Nullable] public bool HasGenerator { get; set; } = false;

        [Nullable] public int RenterId { get; set; }
        public ShowcaseRenter Renter { get; set; } = new ShowcaseRenter();

        [Required] public Guid UserId { get; set; }
        public ShowcaseUser? User { get; set; }
    }
}
