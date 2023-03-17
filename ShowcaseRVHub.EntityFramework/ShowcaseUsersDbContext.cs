using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.EntityFramework.DTOs;

namespace ShowcaseRVHub.EntityFramework
{
    public class ShowcaseUsersDbContext : DbContext
    {
        public ShowcaseUsersDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ShowcaseUserDTO> ShowcaseUsers { get; set; }
    }
}
