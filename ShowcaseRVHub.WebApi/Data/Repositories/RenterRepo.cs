using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class RenterRepo : GenericRepository<ShowcaseRenter, ShowcaseDbContext>, IRenterRepo
    {
        public RenterRepo(ShowcaseDbContext context) : base(context) {}

        public async Task<ShowcaseRenterDto?> GetRenterByIdAsync(int id)
        {
            try
            {
                ShowcaseRenterDto? renter = await Context.Renters
                                                                .Include(r => r.Rentals)
                                                                .Select(r => new ShowcaseRenterDto
                                                                {
                                                                    Id = r.Id,
                                                                    Firstname = r.Firstname,
                                                                    Lastname = r.Lastname,
                                                                    Email = r.Email,
                                                                    Phone = r.Phone,
                                                                    Rentals = r.Rentals!.Select(rl => new RentalDto
                                                                    {
                                                                        Id = rl.Id,
                                                                    }).ToList()
                                                                }).FirstOrDefaultAsyncEF();
                return renter;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<ShowcaseRenterDto>?> GetRentersAsync()
        {
            try
            {
                IEnumerable<ShowcaseRenterDto>? renters = await Context.Renters
                                                                            .Include(r => r.Rentals)
                                                                            .Select(r => new ShowcaseRenterDto
                                                                            {
                                                                                Id = r.Id,
                                                                                Firstname = r.Firstname,
                                                                                Lastname = r.Lastname,
                                                                                Email = r.Email,
                                                                                Phone = r.Phone,
                                                                                Rentals = r.Rentals!.Select(rl => new RentalDto
                                                                                {
                                                                                    Id = rl.Id,
                                                                                }).ToList()
                                                                            }).ToListAsync();
                return renters;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateRenterAsync(ShowcaseRenter renter)
        {
            try
            {
                var updateRenter = await Context.Renters.FirstOrDefaultAsyncEF(r => r.Id == renter.Id);

                if (updateRenter == null)
                    return false;

                updateRenter.Firstname = string.IsNullOrEmpty(renter.Firstname) ? updateRenter.Firstname : renter.Firstname;
                updateRenter.Lastname = string.IsNullOrEmpty(renter.Lastname) ? updateRenter.Lastname : renter.Lastname;
                updateRenter.Phone = string.IsNullOrEmpty(renter.Phone) ? updateRenter.Phone : renter.Phone;
                updateRenter.Email = string.IsNullOrEmpty(renter.Email) ? updateRenter.Email : renter.Email;

                Context.Renters.Update(updateRenter);
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
