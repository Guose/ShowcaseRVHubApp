using ShowcaseRVHub.MAUI.Model.Enums;

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
        public bool IsRenterSigned { get; set; }
        public bool IsUserSigned { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public LevelType FuelLevel { get; set; }
        public LevelType BlackWater { get; set; }
        public LevelType GrayWater { get; set; }
        public LevelType Propane { get; set; }
        public int RenterId { get; set; }
        public RenterModel Renter { get; set; }
        public Guid CheckoutUserId { get; set; }
        public UserModel CheckoutUser { get; set; }
        public Guid? CheckinUserId { get; set; }
        public UserModel? CheckinUser { get; set; }
        public int RVId { get; set; }
        public RVModel RVModel { get; set; }

        public RentalModel()
        {
            
        }
    }
}
