using LinqToDB.Mapping;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowcaseRVHub.WebApi.Models
{
    public class Rental
    {
        [Key] public int Id { get; set; }


        [Required] public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Required] public DateTime RentalStart { get; set; }
        [Required] public DateTime RentalEnd { get; set; }

        
        public int? DepartureId { get; set; }
        [Nullable][ForeignKey("DepartureId")] public Departure? Departure { get; set; }
        public int? ArrivalId { get; set; }
        [Nullable][ForeignKey("ArrivalId")] public Arrival? Arrival { get; set; }


        [Required] public int RenterId { get; set; }
        public ShowcaseRenter? Renter { get; set; }
        [Required] public int VehicleId { get; set; }
        public VehicleRv Vehicle { get; set; }

        public Rental()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = null;
            Renter = new();
            Vehicle = new();
        }
    }
}
