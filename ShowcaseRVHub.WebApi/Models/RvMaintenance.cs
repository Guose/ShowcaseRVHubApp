using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.WebApi.Models
{
    public class RvMaintenance
    {
        [Key] public int Id { get; set; }


        public bool IsTireInspected { get; set; }
        public bool IsMaintenance { get; set; }
        public bool IsFluidChecked { get; set; }
        public bool IsSystemsChecked { get; set; }
        [Required] public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        [Required] public DateTime MaintenanceStart { get; set; }
        [Required] public DateTime MaintenanceEnd { get; set; }


        [Required] public Guid UserId { get; set; }
        public ShowcaseUser User { get; set; }


        [Required] public int VehicleId { get; set; }
        public VehicleRv Vehicle { get; set; }

        public RvMaintenance()
        {
            CreatedOn = DateTime.Now;
            ModifiedOn = null;
            User = new();
            Vehicle = new();
        }
    }
}
