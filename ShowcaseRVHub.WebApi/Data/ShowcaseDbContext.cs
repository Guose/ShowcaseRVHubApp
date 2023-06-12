using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data
{
    public class ShowcaseDbContext : DbContext
    {
        public ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options) : base(options) { }

        public DbSet<ShowcaseUser> ShowcaseUsers => Set<ShowcaseUser>();
        public DbSet<VehicleRV> VehicleRVs => Set<VehicleRV>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
