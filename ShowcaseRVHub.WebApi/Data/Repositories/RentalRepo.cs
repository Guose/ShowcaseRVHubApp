using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class RentalRepo : IRentalRepo
    {
        private readonly ShowcaseDbContext _context;

        public RentalRepo(ShowcaseDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateRentalAsync(Rental rental)
        {
            try
            {
                if (rental == null)
                    return false;

                _context.Rentals.Add(rental);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteRentalAsync(int id)
        {
            try
            {
                var deleteRental = await _context.Rentals.FirstOrDefaultAsyncEF(u => u.Id == id);

                if (deleteRental == null)
                    return false;

                _context.Rentals.Remove(deleteRental);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<Rental?> GetRentalByIdAsync(int id)
        {
            try
            {
                var rental = await _context.Rentals.FirstOrDefaultAsyncEF(u => u.Id == id);

                if (rental != null)
                {
                    var rentQuery = from r in _context.Rentals
                                    join v in _context.VehicleRVs on r.VehicleId equals v.Id
                                    where v.Id == rental.VehicleId
                                    select r;
                }

                return rental;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Rental>?> GetRentalsAsync()
        {
            return await _context.Rentals.ToListAsyncEF();
        }

        public async Task<bool> UpdateRentalAsync(Rental newRental)
        {
            try
            {
                var updateRental = await _context.Rentals.FirstOrDefaultAsyncEF(r => r.Id == newRental.Id);

                if (updateRental == null)
                    return false;

                updateRental.IsExteriorCleaned = newRental.IsExteriorCleaned;
                updateRental.IsInteriorCleaned = newRental.IsInteriorCleaned;
                updateRental.IsTireInspected = newRental.IsTireInspected;
                updateRental.IsMaintenance = newRental.IsMaintenance;
                updateRental.IsFluidChecked = newRental.IsFluidChecked;
                updateRental.IsSignalsChecked = newRental.IsSignalsChecked;
                updateRental.IsSystemsChecked = newRental.IsSystemsChecked;
                updateRental.IsRenterTrained = newRental.IsRenterTrained;

                _context.Rentals.Update(updateRental);
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
