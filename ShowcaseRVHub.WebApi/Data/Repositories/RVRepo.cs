using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class RVRepo : IRVRepo
    {
        public ShowcaseDbContext Context { get; set; }
        public RVRepo(ShowcaseDbContext context)
        {
            Context = context;
        }
        public async Task<bool> CreateVehicleRvAsync(VehicleRVDto rv, Guid userId)
        {
            try
            {
                if (rv == null)
                    return false;
                
                VehicleRv? newRv = new VehicleRv
                {
                    Make = rv.Make,
                    Model = rv.Model,
                    Year = rv.Year,
                    Chassis = rv.Chassis,
                    Class = rv.Class,
                    Sleeps = rv.Sleeps,
                    Length = rv.Length,
                    Height = rv.Height,
                    Image = rv.Image,
                    Description = rv.Description,
                    Odometer = rv.Odometer,
                    GeneratorHours = rv.GeneratorHours,
                    MasterBedType = rv.MasterBedType,
                    IsBooked = rv.IsBooked,
                    HasGenerator = rv.HasGenerator,
                    HasSlideout = rv.HasSlideout,
                    CreatedOn = DateTime.Now,
                    UserId = userId,
                };

                Context.VehicleRVs.Add(newRv);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            try
            {
                VehicleRv? deleteVehicle = await Context.VehicleRVs.FirstOrDefaultAsyncEF(v => v.Id == id);

                if (deleteVehicle == null)
                    return false;

                Context.VehicleRVs.Remove(deleteVehicle);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<VehicleRVDto?> GetVehicleByIdAsync(int id)
        {
            try
            {
                VehicleRVDto? vehicle = await Context.VehicleRVs
                                                        .Include(r => r.Rentals)
                                                        .Include(m => m.RvMaintenances)
                                                        .Select(v => new VehicleRVDto
                                                        {
                                                            Id = v.Id,
                                                            Make = v.Make,
                                                            Model = v.Model,
                                                            Year = v.Year,
                                                            Chassis = v.Chassis,
                                                            Class = v.Class,
                                                            Sleeps = v.Sleeps,
                                                            Length = v.Length,
                                                            Height = v.Height,
                                                            Image = v.Image,
                                                            Description = v.Description,
                                                            Odometer = v.Odometer,
                                                            GeneratorHours = v.GeneratorHours,
                                                            MasterBedType = v.MasterBedType,
                                                            IsBooked = v.IsBooked,
                                                            HasSlideout = v.HasSlideout,
                                                            HasGenerator = v.HasGenerator,
                                                            CreatedOn = v.CreatedOn,
                                                            ModifiedOn = v.ModifiedOn,
                                                            Rentals = v.Rentals!.Select(r => new RentalDto
                                                            {
                                                                Id = r.Id,
                                                            }).ToList(),
                                                            RvMaintenances = v.RvMaintenances!.Select(m => new RvMaintenanceDto
                                                            {
                                                                Id = m.Id,
                                                            }).ToList()
                                                        }).FirstOrDefaultAsyncEF(v => v.Id == id);

                if (vehicle == null)
                    return null;

                return vehicle;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<VehicleRVDto>?> GetVehiclesAsync()
        {
            try
            {
                IEnumerable<VehicleRVDto>? vehicles = await Context.VehicleRVs
                                                                        .Include(r => r.Rentals)
                                                                        .Include(m => m.RvMaintenances)
                                                                        .Select(v => new VehicleRVDto
                                                                        {
                                                                            Id = v.Id,
                                                                            Make = v.Make,
                                                                            Model = v.Model,
                                                                            Year = v.Year,
                                                                            Chassis = v.Chassis,
                                                                            Class = v.Class,
                                                                            Sleeps = v.Sleeps,
                                                                            Length = v.Length,
                                                                            Height = v.Height,
                                                                            Image = v.Image,
                                                                            Description = v.Description,
                                                                            Odometer = v.Odometer,
                                                                            GeneratorHours = v.GeneratorHours,
                                                                            MasterBedType = v.MasterBedType,
                                                                            IsBooked = v.IsBooked,
                                                                            HasSlideout = v.HasSlideout,
                                                                            HasGenerator = v.HasGenerator,
                                                                            CreatedOn = v.CreatedOn,
                                                                            ModifiedOn = v.ModifiedOn,
                                                                            Rentals = v.Rentals!.Select(r => new RentalDto
                                                                            {
                                                                                Id = r.Id,
                                                                            }).ToList(),
                                                                            RvMaintenances = v.RvMaintenances!.Select(m => new RvMaintenanceDto
                                                                            {
                                                                                Id = m.Id,
                                                                            }).ToList()
                                                                        }).ToListAsyncEF();

                if (vehicles == null || !vehicles.Any())
                    return null;

                return vehicles;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<bool> UpdateUserAsync(VehicleRVDto newRv)
        {
            try
            {
                var updateRv = await Context.VehicleRVs.FirstOrDefaultAsyncEF(v => v.Id == newRv.Id);

                if (updateRv == null)
                    return false;

                updateRv.Image = string.IsNullOrEmpty(newRv.Image) ? updateRv.Image : newRv.Image;
                updateRv.Description = string.IsNullOrEmpty(newRv.Description) ? updateRv.Description : newRv.Description;
                updateRv.Odometer = newRv.Odometer < 1 ? updateRv.Odometer : newRv.Odometer;
                updateRv.GeneratorHours = newRv.GeneratorHours < 1 ? updateRv.GeneratorHours : newRv.GeneratorHours;
                updateRv.IsBooked = newRv == null ? updateRv.IsBooked : newRv.IsBooked;
                updateRv.ModifiedOn = DateTime.Now;

                Context.VehicleRVs.Update(updateRv);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }    

        public async Task<VehicleRv?> GetVehicleWithRentalUserAndRenterAsync(int id, Guid userId)
        {
            try
            {
                VehicleRv? vehicle = await Context.VehicleRVs
                                                        .Include(r => r.Rentals)
                                                        .Include(u => u.User)
                                                        .Where(u => u.UserId == userId)
                                                        .FirstOrDefaultAsyncEF(v => v.Id == id);

                if (vehicle == null)
                    return null;
                //else
                //    vehicle.Rentals = vehicle.Rentals.Where(u => u.UserId == userId).ToList();

                return vehicle;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }    
    }
}
