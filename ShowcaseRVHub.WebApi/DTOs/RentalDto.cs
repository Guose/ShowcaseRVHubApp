namespace ShowcaseRVHub.WebApi.DTOs
{
    public class RentalDto
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        public ArrivalDto? Arrival { get; set; }
        public DepartureDto? Departure { get; set; }
        
    }
}