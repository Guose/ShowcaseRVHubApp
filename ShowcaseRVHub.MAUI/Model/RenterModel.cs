using System.Text.Json.Serialization;

namespace ShowcaseRVHub.MAUI.Model
{
    public class RenterModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<RentalModel> Rentals { get; set; }
        public List<RVModel> Vehicles { get; set; }

        public RenterModel()
        {
            Rentals = new List<RentalModel>();
            Vehicles = new List<RVModel>();
        }
    }
}
