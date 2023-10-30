using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowcaseRVHub.WebApi.Models
{
    public class VehicleRvRenter
    {
        [Key, Column(Order = 0)]
        public int? RenterId { get; set; }

        [Key, Column(Order = 1)]
        public int? VehicleId { get; set; }

        [InverseProperty("VehicleRvRenters")]
        public ShowcaseRenter? Renter { get; set; }

        [InverseProperty("VehicleRvRenters")]
        public VehicleRv? Vehicle { get; set; }
    }
}
