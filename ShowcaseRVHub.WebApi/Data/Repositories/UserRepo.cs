using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class UserRepo : GenericRepository<ShowcaseUser, ShowcaseDbContext>, IUserRepo
    {
        public UserRepo(ShowcaseDbContext context) : base(context) {}

        public async Task<IEnumerable<ShowcaseUserDto>?> GetAllUsersAsync()
        {
            try
            {
                IEnumerable<ShowcaseUserDto> users = await Context.ShowcaseUsers
                    .Select(u => new ShowcaseUserDto
                    {
                        Id = u.Id,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Phone = u.Phone,
                        Password = u.Password,
                        Username = u.Username,
                        ModifiedOn = u.ModifiedOn,
                        IsRemembered = u.IsRemembered,

                    }).ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
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
                await SaveAsync();

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
                ShowcaseUser? updateUser = await Context.ShowcaseUsers.FirstOrDefaultAsyncEF(u => u.Id == newUser.Id);

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
                await SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<ShowcaseUserDto>> GetUsersWithVehicles()
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
    }
}
