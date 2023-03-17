using Microsoft.EntityFrameworkCore;

namespace ShowcaseRVHub.EntityFramework
{
    public class ShowcaseUsersDbContextFactory
    {
        private readonly DbContextOptions _options;

        public ShowcaseUsersDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public ShowcaseUsersDbContext Create(DbContextOptions options)
        {
            return new ShowcaseUsersDbContext(options);
        }
    }
}
