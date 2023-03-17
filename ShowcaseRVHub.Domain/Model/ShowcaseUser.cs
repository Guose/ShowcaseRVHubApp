namespace ShowcaseRVHub.Domain.Model
{
    public class ShowcaseUser
    {
        public Guid Id { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Phone { get; }
        public string Username { get; }
        public string Password { get; }
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
