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
        public async Task<bool> CreateRenterAsync(ShowcaseRenter renter)
        {
            try
            {
                if (renter == null)
                    return false;

                _context.Renters.Add(renter);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteRenterAsync(int id)
        {
            try
            {
                ShowcaseRenter? deleteRenter = await _context.Renters.FirstOrDefaultAsyncEF(u => u.Id == id);

                if (deleteRenter == null)
                    return false;

                _context.Renters.Remove(deleteRenter);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ShowcaseRenter?> GetRenterByIdAsync(int id)
        {
            try
            {
                ShowcaseRenter? renter = await _context.Renters.FirstOrDefaultAsyncEF(u => u.Id == id);

                if (renter == null)
                    return null;

                return renter;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<ShowcaseRenter>?> GetRentersAsync()
        {
            try
            {
                return await _context.Renters.ToListAsyncEF();
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
                var updateRenter = await _context.Renters.FirstOrDefaultAsyncEF(r => r.Id == renter.Id);

                if (updateRenter == null)
                    return false;

                updateRenter.Firstname = string.IsNullOrEmpty(renter.Firstname) ? updateRenter.Firstname : renter.Firstname;
                updateRenter.Lastname = string.IsNullOrEmpty(renter.Lastname) ? updateRenter.Lastname : renter.Lastname;
                updateRenter.Phone = string.IsNullOrEmpty(renter.Phone) ? updateRenter.Phone : renter.Phone;
                updateRenter.Email = string.IsNullOrEmpty(renter.Email) ? updateRenter.Email : renter.Email;

                _context.Renters.Update(updateRenter);
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
