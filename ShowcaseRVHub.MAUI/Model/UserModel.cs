using System.ComponentModel.DataAnnotations;

namespace ShowcaseRVHub.MAUI.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsRemembered { get; set; } = false;
    }
}
