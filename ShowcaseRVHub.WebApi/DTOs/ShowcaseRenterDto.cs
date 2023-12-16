using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.DTOs
{
    public class ShowcaseRenterDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public ICollection<Rental>? Rentals { get; set; }
    }
}