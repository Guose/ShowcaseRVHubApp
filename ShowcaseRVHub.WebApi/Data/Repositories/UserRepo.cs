using LinqToDB.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class UserRepo : IUserRepo
    {
        public ShowcaseDbContext Context { get; set; }
        public UserRepo(ShowcaseDbContext context)
        {
            Context = context;
        }
        public async Task<bool> CreateUserAsync(ShowcaseUser user)
        {
            try
            {
                if (user == null)
                    return false;

                Context.ShowcaseUsers.Add(user);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            try
            {
                ShowcaseUser? deleteUser = await Context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == id);

                if (deleteUser == null)
                    return false;

                Context.ShowcaseUsers.Remove(deleteUser);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<ShowcaseUser?> GetUserByIdAsync(Guid id)
        {
            try
            {
                ShowcaseUser? user = await Context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == id);

                if (user == null)
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<IEnumerable<ShowcaseUser>?> GetUsersAsync()
        {
            try
            {
                return await Context.ShowcaseUsers.ToListAsyncEF();
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<bool> UpdateUsersPasswordAsync(Guid userId, ShowcaseUser newUser)
        {
            try
            {
                ShowcaseUser? updateUser = await Context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == userId);

                if (updateUser == null)
                    return false;

                // Update User's password and update ModifiedOn property
                updateUser.Password = string.IsNullOrEmpty(newUser.Password) ? updateUser.Password : newUser.Password;
                updateUser.ModifiedOn = DateTime.Now;

                Context.ShowcaseUsers.Update(updateUser);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateUserAsync(ShowcaseUser newUser)
        {
            try
            {
                var updateUser = await Context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == newUser.Id);

                if (updateUser == null)
                    return false;

                // Update User and update ModifiedOn property
                updateUser.FirstName = string.IsNullOrEmpty(newUser.FirstName) ? updateUser.FirstName : newUser.FirstName;
                updateUser.LastName = string.IsNullOrEmpty(newUser.LastName) ? updateUser.LastName : newUser.LastName;
                updateUser.Email = string.IsNullOrEmpty(newUser.Email) ? updateUser.Email : newUser.Email;
                updateUser.Phone = string.IsNullOrEmpty(newUser.Phone) ? updateUser.Phone : newUser.Phone;
                updateUser.Username = string.IsNullOrEmpty(newUser.Username) ? updateUser.Username : newUser.Username;
                updateUser.Password = string.IsNullOrEmpty(newUser.Password) ? updateUser.Password : newUser.Password;
                updateUser.ModifiedOn = DateTime.Now;
                updateUser.IsRemembered = newUser.IsRemembered;

                Context.ShowcaseUsers.Update(updateUser);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public Task<ShowcaseUser?> GetUserVehicleRVs(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ShowcaseUser?> GetUserRentals(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
