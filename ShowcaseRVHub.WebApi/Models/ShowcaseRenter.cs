namespace ShowcaseRVHub.WebApi.Models
{
    public class ShowcaseRenter
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public List<VehicleRv> Vehicles { get; set; } = new List<VehicleRv>();
    }
}
