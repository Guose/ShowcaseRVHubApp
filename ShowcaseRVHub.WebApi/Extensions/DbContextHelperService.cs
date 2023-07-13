using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data;

namespace ShowcaseRVHub.WebApi.Extensions
{
    public class DbContextHelperService
    {
        private readonly ShowcaseDbContext _context;

        public DbContextHelperService(ShowcaseDbContext context)
        {
            _context = context;
        }

        public async Task MigrateDatabaseAsync()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
