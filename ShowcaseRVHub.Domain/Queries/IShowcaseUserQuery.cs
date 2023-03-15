using ShowcaseRVHub.Domain.Model;

namespace ShowcaseRVHub.Domain.Queries
{
    public interface IShowcaseUserQuery
    {
        Task<IEnumerable<ShowcaseUser>> GetAllShowcaseUsersAsync();

        Task<ShowcaseUser> GetUserByIdAsync(Guid id);
    }
}
