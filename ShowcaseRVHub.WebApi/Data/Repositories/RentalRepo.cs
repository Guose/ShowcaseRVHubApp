using LinqToDB.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class RentalRepo : GenericRepository<Rental, ShowcaseDbContext>, IRentalRepo
    {
        public RentalRepo(ShowcaseDbContext context) : base(context) {}

        public async Task<RentalDto?> GetRentalByIdAsync(int id)
        {
            try
            {
                RentalDto? rental = await Context.Rentals
                                                .Select(r => new RentalDto
                                                {
                                                    Id = r.Id,
                                                    CreatedOn = r.CreatedOn,
                                                    RentalStart = r.RentalStart,
                                                    RentalEnd = r.RentalEnd,
                                                })
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

        public async Task<IEnumerable<RentalDto>?> GetRentalsAsync()
        {
            
            try
            {
                List<RentalDto>? rentals = await Context.Rentals
                                                            .Select(r => new RentalDto
                                                            {
                                                                Id = r.Id,
                                                                CreatedOn = r.CreatedOn,
                                                                RentalStart = r.RentalStart,
                                                                RentalEnd = r.RentalEnd,
                                                            }).ToListAsyncEF();

                if (rentals == null)
                    return null;

                return rentals;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateRentalAsync(RentalDto newRental)
        {
            try
            {
                var updateRental = await Context.Rentals.FirstOrDefaultAsyncEF(r => r.Id == newRental.Id);

                if (updateRental == null)
                    return false;

                updateRental.RentalStart = newRental.RentalStart;
                updateRental.RentalEnd = newRental.RentalEnd;
                updateRental.ModifiedOn = DateTime.Now;

                Context.Rentals.Update(updateRental);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
