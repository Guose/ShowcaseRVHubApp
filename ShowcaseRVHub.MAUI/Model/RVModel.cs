using ShowcaseRVHub.MAUI.Model.Enums;


namespace ShowcaseRVHub.MAUI.Model
{
    public class RVModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Chassis { get; set; }
        public RVClassType Class { get; set; }
        public int Sleeps { get; set; }
        public int Length { get; set; }
        public double Height { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public BedType MasterBedType { get; set; }
        public double Odometer { get; set; }
        public int GeneratorHours { get; set; }
        public bool IsBooked { get; set; }
        public bool HasSlideout { get; set; }
        public bool HasGenerator { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
