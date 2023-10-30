using ShowcaseRVHub.WebApi.Models.EnumTypes;
using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class Arrival
    {
        [Key] public int Id { get; set; }


        public bool IsExteriorCleaned { get; set; }
        public bool IsInteriorCleaned { get; set; }
        public bool IsSignalsChecked { get; set; }
        public bool IsCheckInComplete { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; } = null;
        [Required] public LevelType FuelLevel { get; set; }
        [Required] public LevelType BlackWater { get; set; }
        [Required] public LevelType GrayWater { get; set; }
        [Required] public LevelType Propane { get; set; }


        [Required] public Guid UserId { get; set; }
        public ShowcaseUser User { get; set; }
        [Required] public int RentalId { get; set; }
        public Rental Rental { get; set; }

        public Arrival()
        {
            User = new();
            Rental = new();
        }
    }
}
