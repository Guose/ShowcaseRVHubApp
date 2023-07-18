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
                var rental = await _context.Rentals
                                                .Include(r => r.Renter)
                                                .Include(u => u.User)
                                                .Include(v => v.Vehicle)
                                                .FirstOrDefaultAsyncEF(u => u.Id == id);

                if (rental == null)
                    return null;

                return rental;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<Rental>?> GetRentalsAsync()
        {
            
            try
            {
                List<Rental> rentals = await _context.Rentals
                                                    .Include(r => r.Renter)
                                                    .Include(u => u.User)
                                                    .Include(v => v.Vehicle)
                                                    .ToListAsyncEF();

                if (rentals == null)
                    return null;

                return rentals;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
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
                updateRental.RentalStart = newRental.RentalStart;
                updateRental.RentalEnd = newRental.RentalEnd;
                updateRental.ModifiedOn = DateTime.Now;

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
