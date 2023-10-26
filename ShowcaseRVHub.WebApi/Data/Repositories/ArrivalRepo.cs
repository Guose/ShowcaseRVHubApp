using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class ArrivalRepo : IArrivalRepo
    {
        private readonly ShowcaseDbContext _context;

        public ArrivalRepo(ShowcaseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateArrivalAsync(Arrival arrival)
        {
            try
            {
                if (arrival == null)
                    return false;

                _context.Arrivals.Add(arrival);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteArrivalAsync(int id)
        {
            try
            {
                Arrival? deleteArrival = await _context.Arrivals.FirstOrDefaultAsyncEF(x => x.Id == id);

                if (deleteArrival == null)
                    return false;

                _context.Arrivals.Remove(deleteArrival);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Arrival?> GetArrivalByIdAsync(int id)
        {
            try
            {
                Arrival? arrival = await _context.Arrivals
                                                    .Include(u => u.User)
                                                    .FirstOrDefaultAsyncEF(x => x.Id == id);
                if (arrival == null)
                    return null;

                return arrival;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Arrival>?> GetArrivalsAsync()
        {
            try
            {
                List<Arrival> arrivals = await _context.Arrivals
                                                    .Include(u => u.User)
                                                    .ToListAsyncEF();
                if (arrivals == null)
                    return null;

                return arrivals;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateArrivalAsync(Arrival newArrival)
        {
            try
            {
                Arrival? arrival = await _context.Arrivals.FirstOrDefaultAsyncEF(a => a.Id == newArrival.Id);

                if (arrival == null) 
                    return false;

                Arrival updateArrival = new Arrival
                {
                    IsExteriorCleaned = newArrival.IsExteriorCleaned,
                    IsInteriorCleaned = newArrival.IsInteriorCleaned,
                    IsSignalsChecked = newArrival.IsSignalsChecked,
                    IsCheckInComplete = newArrival.IsCheckInComplete,
                    FuelLevel = newArrival.FuelLevel,
                    BlackWater = newArrival.BlackWater,
                    GrayWater = newArrival.GrayWater,
                    Propane = newArrival.Propane,
                    ModifiedOn = DateTime.Now,
                };


                _context.Arrivals.Update(updateArrival);
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
