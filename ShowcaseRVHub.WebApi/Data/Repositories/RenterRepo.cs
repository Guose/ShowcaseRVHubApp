using LinqToDB.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class RenterRepo : IRenterRepo
    {
        private readonly ShowcaseDbContext _context;

        public RenterRepo(ShowcaseDbContext context)
        {
            _context = context;
        }
        public async Task CreateRenterAsync(ShowcaseRenter renter)
        {
            if (renter == null)
                return;

            _context.Renters.Add(renter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRenterAsync(int id)
        {
            var deleteRenter = await _context.Renters.FirstOrDefaultAsyncEF(u => u.Id == id);

            if (deleteRenter == null)
                throw new ArgumentNullException(nameof(deleteRenter));

            _context.Renters.Remove(deleteRenter);
            await _context.SaveChangesAsync();
        }

        public async Task<ShowcaseRenter> GetRenterByIdAsync(int id)
        {
            var renter = await _context.Renters.FirstOrDefaultAsyncEF(u => u.Id == id);

            if (renter == null)
                throw new ArgumentNullException(nameof(renter));

            return renter;
        }

        public async Task<IEnumerable<ShowcaseRenter>> GetRentersAsync()
        {
            return await _context.Renters.ToListAsyncEF();
        }

        public async Task UpdateRenterAsync(ShowcaseRenter renter)
        {
            var updateRenter = await _context.Renters.FirstOrDefaultAsyncEF(r => r.Id == renter.Id);

            if (updateRenter == null)
                return;

            updateRenter.Firstname = string.IsNullOrEmpty(renter.Firstname) ? updateRenter.Firstname : renter.Firstname;
            updateRenter.Lastname = string.IsNullOrEmpty(renter.Lastname) ? updateRenter.Lastname : renter.Lastname;
            updateRenter.Phone = string.IsNullOrEmpty(renter.Phone) ? updateRenter.Phone : renter.Phone;
            updateRenter.Email = string.IsNullOrEmpty(renter.Email) ? updateRenter.Email : renter.Email;

            _context.Renters.Update(updateRenter);
            await _context.SaveChangesAsync();
        }
    }
}
