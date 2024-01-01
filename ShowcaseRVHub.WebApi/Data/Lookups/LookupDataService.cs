using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Lookups
{
    public class LookupDataService : IArrivalLookupDataService, IDepartureLookupDataService, IRentalLookupDataService,
    IRenterLookupDataService, IRvMaintenanceLookupDataService, IUserLookupDataService, IVehicleLookupDataService
    {
        private Func<ShowcaseDbContext> _contextCreator;
        public LookupDataService(Func<ShowcaseDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<LookupItem>> GetArrivalLookupAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.Arrivals.AsNoTracking()
                .Select(a => new LookupItem
                {
                    Id = a.Id,
                    DisplayMember = nameof(Arrival),
                }).ToListAsyncEF();
        }

        public async Task<List<LookupItem>> GetDepartureLookupAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.Departures.AsNoTracking()
                .Select(d => new LookupItem
                {
                    Id = d.Id,
                    DisplayMember = nameof(Departure),
                }).ToListAsyncEF();
        }

        public async Task<List<LookupItem>> GetMaintenanceLookupAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.Maintenances.AsNoTracking()
                .Select(m => new LookupItem
                {
                    Id = m.Id,
                    DisplayMember = nameof(RvMaintenance),
                }).ToListAsyncEF();
        }

        public async Task<IEnumerable<LookupItem>> GetRentalLookupAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.Rentals.AsNoTracking()
                .Select(rl => new LookupItem
                {
                    Id = rl.Id,
                    DisplayMember = nameof(Rental),
                }).ToListAsyncEF();
        }

        public async Task<IEnumerable<LookupItem>> GetRenterLookupAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.Renters.AsNoTracking()
                .Select(re => new LookupItem
                {
                    Id = re.Id,
                    DisplayMember = nameof(ShowcaseRenter),
                }).ToListAsyncEF();
        }

        public async Task<IEnumerable<LookupItem>> GetUserLookupAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.ShowcaseUsers.AsNoTracking()
                .Select(u => new LookupItem
                {
                    UserId = u.Id,
                    DisplayMember = u.FirstName + " " + u.LastName,
                }).ToListAsyncEF();
        }

        public async Task<IEnumerable<LookupItem>> GetVehicleLookupAsync()
        {
            using var ctx = _contextCreator();
            return await ctx.VehicleRVs.AsNoTracking()
                .Select(a => new LookupItem
                {
                    Id = a.Id,
                    DisplayMember = nameof(VehicleRv),
                }).ToListAsyncEF();
        }
    }
}