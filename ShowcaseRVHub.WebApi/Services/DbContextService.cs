using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data;

namespace ShowcaseRVHub.WebApi.Services
{
    public class DbContextService
    {
        private readonly ShowcaseDbContext _context;

        public DbContextService(ShowcaseDbContext context)
        {
            _context = context;
        }

        public async Task MigrateDatabaseAsync()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
