using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.Domain.Model;
using ShowcaseRVHub.Domain.Queries;
using ShowcaseRVHub.EntityFramework.DTOs;

namespace ShowcaseRVHub.EntityFramework.Queries
{
    public class ShowcaseUserQuery : IShowcaseUserQuery
    {
        private readonly ShowcaseUsersDbContextFactory _contextFactory;

        public ShowcaseUserQuery(ShowcaseUsersDbContextFactory contextFactory)
        {            
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<ShowcaseUser>> GetAllShowcaseUsersAsync()
        {
            using (var context = _contextFactory.Create())
            {
                IEnumerable<ShowcaseUserDTO> showcaseUsers = await context.ShowcaseUsers.ToListAsync();

                return showcaseUsers.Select(s => new ShowcaseUser(s.Id, s.Email, s.FirstName, s.LastName, s.Phone, s.Username, s.Password, s.IsRemembered));
            }
        }

        public async Task<ShowcaseUser> GetUserByIdAsync(Guid id)
        {
            using (var context = _contextFactory.Create())
            {
                ShowcaseUserDTO showcaseUser = await context.ShowcaseUsers.FirstAsync(u => u.Id == id).ConfigureAwait(false);

                return new ShowcaseUser(
                    showcaseUser.Id,
                    showcaseUser.Email,
                    showcaseUser.FirstName,
                    showcaseUser.LastName,
                    showcaseUser.Phone,
                    showcaseUser.Username,
                    showcaseUser.Password,
                    showcaseUser.IsRemembered);
            }
        }
    }
}
