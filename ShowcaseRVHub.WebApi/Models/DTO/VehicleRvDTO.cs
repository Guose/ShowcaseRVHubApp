using ShowcaseRVHub.WebApi.Models.EnumTypes;

namespace ShowcaseRVHub.WebApi.Models.DTO
{
    public class VehicleRvDTO
    {
        public int Id { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Odometer { get; set; }
        public int GeneratorHours { get; set; }
        public LevelType FuelLevel { get; set; }
        public bool IsBooked { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
