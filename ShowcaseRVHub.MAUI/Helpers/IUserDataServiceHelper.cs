namespace ShowcaseRVHub.MAUI.Helpers
{
    public interface IUserDataServiceHelper
    {
        Task<UserModel> GetUserByEmailAsync(string email);
    }
}
