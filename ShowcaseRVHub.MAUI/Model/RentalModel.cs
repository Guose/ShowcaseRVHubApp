namespace ShowcaseRVHub.MAUI.Model
{
    public class RentalModel
    {
        public int Id { get; set; }
        public bool IsExteriorCleaned { get; set; }
        public bool IsInteriorCleaned { get; set; }
        public bool IsTiresInspected { get; set; }
        public bool IsMaintenance { get; set; }
        public bool IsFluidChecked { get; set; }
        public bool IsSignalChecked { get; set; }
        public bool IsSystemsChecked { get; set; }
        public bool IsRenterTrained { get; set; }
        public DateTime? RentalStart { get; set; }
        public DateTime? RentalEnd { get; set; }

        public int RenterId { get; set; }
        public RenterModel Renter { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public int RVId { get; set; }
        public RVModel RVModel { get; set; }

        public RentalModel()
        {
            
        }
    }
}
