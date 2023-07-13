using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data;
using ShowcaseRVHub.WebApi.Extensions;

namespace ShowcaseRVHub.XUnitTest
{
    public class ShowcaseDbContextHelper
    {
        /// <summary>
        /// Returns an instance of the In-Memory context for tests
        /// </summary>
        /// <param name="name"></param>
        /// <returns>In-Memory DbContext</returns>
        public static ShowcaseDbContext GetMockDb(string name)
        {            
            var options = new DbContextOptionsBuilder<ShowcaseDbContext>()
                .UseInMemoryDatabase(name)
                .Options;

            var db = new ShowcaseDbContext(options);            

            // Seed In-Memory database
            if (!db.ShowcaseUsers.Any())
            {
                db.ShowcaseUsers.AddRangeAsync(DbSeedData.GetUserSeedData());
                db.SaveChangesAsync();
            }

            if (!db.Renters.Any())
            {
                db.Renters.AddRangeAsync(DbSeedData.GetRenterSeedData());
                db.SaveChangesAsync();
            }

            if (!db.VehicleRVs.Any())
            {
                db.VehicleRVs.AddRangeAsync(DbSeedData.GetRvSeedData());
                db.SaveChangesAsync();
            }

            if (!db.Rentals.Any())
            {
                db.Rentals.AddRangeAsync(DbSeedData.GetRentalSeedData());
                db.SaveChangesAsync();
            }
            return db;
        }
    }
}
