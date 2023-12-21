using ShowcaseRVHub.WebApi.Models.EnumTypes;

namespace ShowcaseRVHub.WebApi.DTOs
{
    public class ArrivalDto
    {
        public int Id { get; set; }
        public bool IsExteriorCleaned { get; set; }
        public bool IsInteriorCleaned { get; set; }
        public bool IsSignalsChecked { get; set; }
        public bool IsCheckInComplete { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public LevelType FuelLevel { get; set; }
        public LevelType BlackWater { get; set; }
        public LevelType GrayWater { get; set; }
        public LevelType Propane { get; set; }
    }
}