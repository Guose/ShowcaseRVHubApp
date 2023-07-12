using LinqToDB.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using ShowcaseRVHub.WebApi.Data.Interfaces;
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
        public async Task<bool> CreateVehicleRvAsync(VehicleRv rv)
        {
            try
            {
                if (rv == null)
                    return false;

                Context.VehicleRVs.Add(rv);
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

        public async Task<VehicleRv?> GetVehicleByIdAsync(int id)
        {
            try
            {
                VehicleRv? vehicle = await Context.VehicleRVs.FirstOrDefaultAsyncEF(v => v.Id == id);

                if (vehicle == null)
                    return null;

                return vehicle;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<VehicleRv>?> GetVehiclesAsync()
        {
            try
            {
                return await Context.VehicleRVs.ToListAsyncEF();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateRvWithRenter(VehicleRv rv, ShowcaseRenter renter)
        {
            try
            {
                VehicleRv? updateRv = await Context.VehicleRVs.FirstOrDefaultAsyncEF(rv => rv.Id == rv.Id);

                if (updateRv == null)
                    return false;

                updateRv.RenterId = renter.Id;
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

        public async Task<bool> UpdateUserAsync(VehicleRv newRv)
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
                updateRv.FuelLevel = newRv == null ? updateRv.FuelLevel : newRv.FuelLevel;
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
    }
}
