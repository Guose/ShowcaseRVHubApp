namespace ShowcaseRVHub.Domain.Model
{
    public class ShowcaseUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ShowcaseUser(Guid id, string email, string username, string password)
        {
            Id = id;
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
