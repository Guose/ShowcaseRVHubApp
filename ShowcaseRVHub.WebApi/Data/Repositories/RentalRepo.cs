using LinqToDB.EntityFrameworkCore;
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
        public async Task CreateRentalAsync(Rental rental)
        {
            if (rental == null)
                return;

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalAsync(int id)
        {
            var deleteRental = await _context.Rentals.FirstOrDefaultAsyncEF(u => u.Id == id);

            if (deleteRental == null)
                throw new ArgumentNullException(nameof(deleteRental));

            _context.Rentals.Remove(deleteRental);
            await _context.SaveChangesAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            var rental = await _context.Rentals.FirstOrDefaultAsyncEF(u => u.Id == id);

            if (rental == null)
                throw new ArgumentNullException(nameof(rental));

            return rental;
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync()
        {
            return await _context.Rentals.ToListAsyncEF();
        }

        public async Task UpdateRentalAsync(Rental newRental)
        {
            var updateRental = await _context.Rentals.FirstOrDefaultAsyncEF(r => r.Id == newRental.Id);

            if (updateRental == null)
                return;

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
        }
    }
}
