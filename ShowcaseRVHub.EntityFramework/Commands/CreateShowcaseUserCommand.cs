using ShowcaseRVHub.Domain.Commands;
using ShowcaseRVHub.Domain.Model;
using ShowcaseRVHub.EntityFramework.DTOs;

namespace ShowcaseRVHub.EntityFramework.Commands
{
    public class CreateShowcaseUserCommand : ICreateShowcaseUserCommand
    {
        private readonly ShowcaseUsersDbContextFactory _contextFactory;

        public CreateShowcaseUserCommand(ShowcaseUsersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task ExecuteCreateAsync(ShowcaseUser user)
        {
            using (var context = _contextFactory.Create())
            {
                ShowcaseUserDTO showcaseUser = new ShowcaseUserDTO
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Username = user.Username,
                    Password = user.Password,
                    IsRemembered = user.IsRemembered,
                };

                await context.ShowcaseUsers.AddAsync(showcaseUser);
                await context.SaveChangesAsync();
            }
        }
    }
}
