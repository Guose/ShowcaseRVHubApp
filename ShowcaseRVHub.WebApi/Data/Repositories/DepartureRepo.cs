using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
   public class DepartureRepo : IDepartureRepo
   {
        private readonly ShowcaseDbContext _context;

        public DepartureRepo(ShowcaseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDepartureAsync(Departure departure)
        {
            try
            {
                if (departure == null)
                    return false;

                _context.Departures.Add(departure);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteDepartureAsync(int id)
        {
            try
            {
                Departure? deleteDeparture = await _context.Departures.FirstOrDefaultAsyncEF(d => d.Id == id);

                if (deleteDeparture == null)
                    return false;

                _context.Departures.Remove(deleteDeparture);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Departure?> GetDepartureByIdAsync(int id)
        {
            try
            {
                Departure? departure = await _context.Departures
                                                            .Include(u => u.User)
                                                            .FirstOrDefaultAsyncEF(x => x.Id == id);
                if (departure == null)
                    return null;

                return departure;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Departure>?> GetDeparturesAsync()
        {
            try
            {
                List<Departure> departures = await _context.Departures
                                                            .Include(u => u.User)
                                                            .ToListAsyncEF();
                if (departures == null)
                    return null;

                return departures;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateDepartureAsync(Departure newDeparture)
        {
            try
            {
                Departure? departure = await _context.Departures.FirstOrDefaultAsyncEF(x => x.Id == newDeparture.Id);

                if (departure == null)
                    return false;

                Departure updateDeparture = new Departure
                {
                    IsExteriorCleaned = newDeparture.IsExteriorCleaned,
                    IsInteriorCleaned = newDeparture.IsInteriorCleaned,
                    IsSignalsChecked = newDeparture.IsSignalsChecked,
                    IsRenterTrained = newDeparture.IsRenterTrained,
                    FuelLevel = newDeparture.FuelLevel,
                    BlackWater = newDeparture.BlackWater,
                    GrayWater = newDeparture.GrayWater,
                    Propane = newDeparture.Propane,
                    ModifiedOn = DateTime.Now,
                };

                _context.Departures.Update(updateDeparture);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
