namespace ShowcaseRVHub.MAUI.Model
{
    public class RenterModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<RenterModel> Rentals { get; set; }
    }
}
