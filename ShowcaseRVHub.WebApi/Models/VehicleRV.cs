using Newtonsoft.Json;
using ShowcaseRVHub.WebApi.Models.EnumTypes;
using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class VehicleRv
    {
        [Key] public int Id { get; set; }
        [Required] public string Make { get; set; } = string.Empty;
        [Required] public string Model { get; set; } = string.Empty;
        public int? Year { get; set; }
        public string? Chassis { get; set; }
        [Required] public RVClassType Class { get; set; }
        [Required] public int Sleeps { get; set; }
        public int? Length { get; set; }
        public double? Height { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Required] public double Odometer { get; set; }
        [Required] public int GeneratorHours { get; set; }
        [Required] public BedType MasterBedType { get; set; }
        [Required] public bool IsBooked { get; set; }
        public bool? HasSlideout { get; set; }
        public bool? HasGenerator { get; set; }

        [Required] public Guid? UserId { get; set; }
        public ShowcaseUser? User { get; set; }

        public List<Rental>? Rentals { get; set; }

        public VehicleRv()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = null;
        }
    }
}
