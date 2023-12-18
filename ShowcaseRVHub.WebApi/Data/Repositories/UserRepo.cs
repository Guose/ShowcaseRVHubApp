using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
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
        public async Task<bool> CreateUserAsync(ShowcaseUserDto user)
        {
            try
            {
                if (user == null)
                    return false;
                
                ShowcaseUser? newUser = new ShowcaseUser
                {
                    Id = Guid.NewGuid(),
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    Username = user.Username,
                    Password = user.Password,
                    CreatedOn = DateTime.Now,
                };

                Context.ShowcaseUsers.Add(newUser);
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

        public async Task<ShowcaseUserDto?> GetUserByIdAsync(Guid id)
        {
            try
            {
                ShowcaseUserDto? user = await Context.ShowcaseUsers
                                                            .Include(a => a.Arrivals)
                                                            .Include(d => d.Departures)
                                                            .Include(v => v.Vehicles!)
                                                                .ThenInclude(m => m.RvMaintenances)
                                                            .Select(u => new ShowcaseUserDto
                                                            {
                                                                Id = u.Id,
                                                                Email = u.Email,
                                                                FirstName = u.FirstName,
                                                                LastName = u.LastName,
                                                                Phone = u.Phone,
                                                                Username = u.Username,
                                                                Password = u.Password,
                                                                CreatedOn = u.CreatedOn,
                                                                ModifiedOn = DateTime.Now,
                                                                IsRemembered = u.IsRemembered,
                                                                Arrivals = u.Arrivals!.Select(a => new ArrivalDto
                                                                {
                                                                    Id = a.Id,
                                                                }).ToList(),
                                                                Departures = u.Departures!.Select(d => new DepartureDto
                                                                {
                                                                    Id = d.Id,
                                                                }).ToList(),
                                                                Vehicles = u.Vehicles!.Select(r => new VehicleRVDto
                                                                {
                                                                    Id = r.Id,
                                                                    Rentals = r.Rentals!.Select(re => new RentalDto
                                                                    {
                                                                        Id = re.Id,
                                                                    }).ToList(),
                                                                    RvMaintenances = r.RvMaintenances!.Select(m => new RvMaintenanceDto
                                                                    {
                                                                        Id = m.Id,
                                                                    }).ToList()
                                                                }).ToList()
                                                            }).FirstOrDefaultAsyncEF(u => u.Id == id);

                if (user == null)
                    return null;

                return user;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<IEnumerable<ShowcaseUserDto>?> GetUsersAsync()
        {
            try
            {
                IEnumerable<ShowcaseUserDto>? userDto = await Context.ShowcaseUsers
                                                                            .Include(a => a.Arrivals)
                                                                            .Include(d => d.Departures)
                                                                            .Include(v => v.Vehicles!)
                                                                                .ThenInclude(m => m.RvMaintenances)
                                                                            .Select(u => new ShowcaseUserDto
                                                                            {
                                                                                Id = u.Id,
                                                                                Email = u.Email,
                                                                                FirstName = u.FirstName,
                                                                                LastName = u.LastName,
                                                                                Phone = u.Phone,
                                                                                Username = u.Username,
                                                                                Password = u.Password,
                                                                                CreatedOn = u.CreatedOn,
                                                                                ModifiedOn = DateTime.Now,
                                                                                IsRemembered = u.IsRemembered,
                                                                                Arrivals = u.Arrivals!.Select(a => new ArrivalDto
                                                                                {
                                                                                    Id = a.Id,
                                                                                }).ToList(),
                                                                                Departures = u.Departures!.Select(d => new DepartureDto
                                                                                {
                                                                                    Id = d.Id,
                                                                                }).ToList(),
                                                                                Vehicles = u.Vehicles!.Select(r => new VehicleRVDto
                                                                                {
                                                                                    Id = r.Id,
                                                                                    Rentals = r.Rentals!.Select(re => new RentalDto
                                                                                    {
                                                                                        Id = re.Id,
                                                                                    }).ToList(),
                                                                                    RvMaintenances = r.RvMaintenances!.Select(m => new RvMaintenanceDto
                                                                                    {
                                                                                        Id = m.Id,
                                                                                    }).ToList()
                                                                                }).ToList()
                                                                            }).ToListAsync();

                return userDto;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<bool> UpdateUsersPasswordAsync(Guid userId, ShowcaseUserDto newUser)
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

        public async Task<bool> UpdateUserAsync(ShowcaseUserDto newUser)
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
    }
}
