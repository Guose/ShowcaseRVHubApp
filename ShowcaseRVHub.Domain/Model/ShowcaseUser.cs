namespace ShowcaseRVHub.Domain.Model
{
    public class ShowcaseUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsRemembered { get; set; } = false;

        public ShowcaseUser(Guid id, string email, string firstName, string lastName, string phone, string username, string password, bool isRemembered)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Username = username;
            Password = password;
            IsRemembered = isRemembered;
        }
    }
}
