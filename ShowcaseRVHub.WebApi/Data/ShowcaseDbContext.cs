using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Extensions;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data
{
    public class ShowcaseDbContext : DbContext
    {
        public ShowcaseDbContext(DbContextOptions<ShowcaseDbContext> options) : base(options) { }

        public DbSet<ShowcaseUser> ShowcaseUsers => Set<ShowcaseUser>();
        public DbSet<ShowcaseRenter> Renters => Set<ShowcaseRenter>();
        public DbSet<Rental> Rentals => Set<Rental>();
        public DbSet<VehicleRv> VehicleRVs => Set<VehicleRv>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
    }
}
