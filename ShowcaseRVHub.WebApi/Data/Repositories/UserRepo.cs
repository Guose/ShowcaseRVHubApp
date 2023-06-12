using LinqToDB.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly ShowcaseDbContext _context;
        public UserRepo(ShowcaseDbContext context)
        {
            _context = context;
        }
        public async Task CreateUserAsync(ShowcaseUser user)
        {
            if (user == null)
                return;

            _context.ShowcaseUsers.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var deleteUser = await _context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == id);

            if (deleteUser == null)
                throw new ArgumentNullException(nameof(deleteUser));

            _context.ShowcaseUsers.Remove(deleteUser);
            await _context.SaveChangesAsync();
        }

        public async Task<ShowcaseUser> GetUserByIdAsync(Guid id)
        {
            var user = await _context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == id);

            if(user == null)
                throw new ArgumentNullException(nameof(user));

            return user;
        }

        public async Task<IEnumerable<ShowcaseUser>> GetUsersAsync()
        {
            return await _context.ShowcaseUsers.ToListAsyncEF();
        }

        public async Task UpdateUsersPasswordAsync(Guid userId, ShowcaseUser user)
        {
            var updateUser = await _context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == userId);

            if (updateUser == null)
                return;

            updateUser.Password = user.Password;

            _context.ShowcaseUsers.Update(updateUser);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(ShowcaseUser newUser)
        {
            var updateUser = await _context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == newUser.Id);

            if (updateUser == null)
                return;

            updateUser.FirstName = string.IsNullOrEmpty(newUser.FirstName) ? updateUser.FirstName : newUser.FirstName;
            updateUser.LastName = string.IsNullOrEmpty(newUser.LastName) ? updateUser.LastName : newUser.LastName;
            updateUser.Email = string.IsNullOrEmpty(newUser.Email) ? updateUser.Email : newUser.Email;
            updateUser.Phone = string.IsNullOrEmpty(newUser.Phone) ? updateUser.Phone : newUser.Phone;
            updateUser.Username = string.IsNullOrEmpty(newUser.Username) ? updateUser.Username : newUser.Username;
            updateUser.Password = string.IsNullOrEmpty(newUser.Password) ? updateUser.Password : newUser.Password;
            updateUser.ModifiedOn = DateTime.Now;
            updateUser.IsRemembered = newUser.IsRemembered;

            _context.ShowcaseUsers.Update(updateUser);
            await _context.SaveChangesAsync();
        }
    }
}
