using ShowcaseRVHub.WebApi.Models.EnumTypes;

namespace ShowcaseRVHub.WebApi.DTOs
{
    public class VehicleRVDto
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int? Year { get; set; }
        public string? Chassis { get; set; }
        public RVClassType Class { get; set; }
        public int Sleeps { get; set; }
        public int? Length { get; set; }
        public double? Height { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public double Odometer { get; set; }
        public int GeneratorHours { get; set; }
        public BedType MasterBedType { get; set; }
        public bool IsBooked { get; set; }
        public bool? HasSlideout { get; set; }
        public bool? HasGenerator { get; set; }
        public ICollection<RentalDto>? Rentals { get; set; }
        public ICollection<RvMaintenanceDto>? RvMaintenances { get; set; }
    }
}