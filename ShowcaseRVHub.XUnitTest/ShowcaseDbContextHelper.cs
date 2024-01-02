using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Extensions;

namespace ShowcaseRVHub.XUnitTest
{
    public class ShowcaseDbContextHelper
    {
        private readonly ShowcaseDbContext? db;
        private readonly DbContextOptions<ShowcaseDbContext> dbOptions;
        public ShowcaseDbContextHelper(string name)
        {
            dbOptions = new DbContextOptionsBuilder<ShowcaseDbContext>()
                .UseInMemoryDatabase(name)
                .Options;

            db = new ShowcaseDbContext(dbOptions);
        }

        /// <summary>
        /// Returns an instance of the In-Memory context for tests
        /// </summary>
        /// <param name="name">string</param>
        /// <param name="db">ShowcaseDbContext</param>
        /// <returns>In-Memory DbContext</returns>
        public async Task<ShowcaseDbContext> GetMockDbAsync()
        {
            // Seed In-Memory database
            if (!db!.ShowcaseUsers.Any())
            {
                await db.ShowcaseUsers.AddRangeAsync(DbSeedData.GetUserSeedData());
                await db.SaveChangesAsync();
            }
            if (!db.VehicleRVs.Any())
            {
                await db.VehicleRVs.AddRangeAsync(DbSeedData.GetRvSeedData());
                await db.SaveChangesAsync();
            }
            if (!db.Renters.Any())
            {
                await db.Renters.AddRangeAsync(DbSeedData.GetRenterSeedData());
                await db.SaveChangesAsync();
            }
            if (!db.Rentals.Any())
            {
                await db.Rentals.AddRangeAsync(DbSeedData.GetRentalSeedData());
                await db.SaveChangesAsync();
            }
            if (!db.Departures.Any())
            {
                await db.Departures.AddRangeAsync(DbSeedData.GetDepartureSeedData());
                await db.SaveChangesAsync();
            }
            if (!db.Arrivals.Any())
            {
                await db.Arrivals.AddRangeAsync(DbSeedData.GetArrivalSeedData());
                await db.SaveChangesAsync();
            }
            if (!db.Maintenances.Any())
            {
                await db.Maintenances.AddRangeAsync(DbSeedData.GetMaintenanceSeedData());
                await db.SaveChangesAsync();
            }

            return db;
        }
    }
}
