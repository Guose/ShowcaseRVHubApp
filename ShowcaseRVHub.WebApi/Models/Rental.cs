﻿using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class Rental
    {
        [Key] public int Id { get; set; }
        [Required] public bool IsExteriorCleaned { get; set; }
        [Required] public bool IsInteriorCleaned { get; set; }
        [Required] public bool IsTireInspected { get; set; }
        [Required] public bool IsMaintenance { get; set; }
        [Required] public bool IsFluidChecked { get; set; }
        [Required] public bool IsSignalsChecked { get; set; }
        [Required] public bool IsSystemsChecked { get; set; }
        [Required] public bool IsRenterTrained { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int RenterId { get; set; }
        public ShowcaseRenter? Renter { get; set; }

        public Guid UserId { get; set; }
        public ShowcaseUser? User { get; set; }

        public int VehicleId { get; set; }
        public VehicleRv? Vehicle { get; set; }

        public Rental()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = null;
        }
    }
}
