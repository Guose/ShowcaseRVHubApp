using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Extensions
{
    public static class DbContextModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ShowcaseRenter>().HasData(DbSeedData.GetRenterSeedData());
            modelBuilder.Entity<VehicleRv>().HasData(DbSeedData.GetRvSeedData());
            //modelBuilder.Entity<Rental>().HasData(DbSeedData.GetRentalSeedData());
        }
    }
}
