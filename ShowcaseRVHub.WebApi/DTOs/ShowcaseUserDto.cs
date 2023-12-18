using System.Text.Json.Serialization;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.DTOs
{
    public class ShowcaseUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsRemembered { get; set; } = false;
        public ICollection<ArrivalDto>? Arrivals { get; set; }
        public ICollection<DepartureDto>? Departures { get; set; }
        public ICollection<VehicleRVDto>? Vehicles { get; set; }

        public static implicit operator ShowcaseUserDto?(ShowcaseUser? v)
        {
            throw new NotImplementedException();
        }
    }
}