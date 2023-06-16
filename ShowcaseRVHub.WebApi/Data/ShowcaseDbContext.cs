using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data
{
    public class ShowcaseDbContext : DbContext
    {
        public ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options) : base(options) { }

        public DbSet<ShowcaseUser> ShowcaseUsers => Set<ShowcaseUser>();
        public DbSet<VehicleRv> VehicleRVs => Set<VehicleRv>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
