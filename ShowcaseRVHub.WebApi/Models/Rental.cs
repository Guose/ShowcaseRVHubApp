using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class Rental
    {
        [Required] public int Id { get; set; }
        [Required] public bool IsExteriorCleaned { get; set; }
        [Required] public bool IsInteriorCleaned { get; set; }
        [Required] public bool IsTireInspected { get; set; }
        [Required] public bool IsMaintenance { get; set; }
        [Required] public bool IsFluidChecked { get; set; }
        [Required] public bool IsSignalsChecked { get; set; }
        [Required] public bool IsSystemsChecked { get; set; }
        [Required] public bool IsRenterTrained { get; set; }

        [Required] public int RentalId { get; set; }
        public ShowcaseRenter? Renter { get; set; }

        [Required] public int UserId { get; set; }
        public 
    }
}
