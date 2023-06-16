﻿using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class RVRepo : IRVRepo
    {
        private readonly ShowcaseDbContext _context;
        public RVRepo(ShowcaseDbContext context)
        {
            _context = context;
        }
        public async Task CreateVehicleRvAsync(VehicleRv rv)
        {
            if (rv == null)
                throw new ArgumentNullException(nameof(rv));

            _context.VehicleRVs.Add(rv);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var deleteVehicle = await _context.VehicleRVs.FirstOrDefaultAsyncEF(v => v.Id == id);

            if (deleteVehicle == null)
                throw new ArgumentNullException(nameof(deleteVehicle));

            _context.VehicleRVs.Remove(deleteVehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<VehicleRv> GetVehicleByIdAsync(int id)
        {
            var vehicle = await _context.VehicleRVs.FirstOrDefaultAsyncEF(v => v.Id == id);

            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            return vehicle;
        }

        public async Task<IEnumerable<VehicleRv>> GetVehiclesAsync()
        {
            return await _context.VehicleRVs.ToListAsyncEF();
        }

        public async Task UpdateUserAsync(VehicleRv newRv)
        {
            var updateRv = await _context.VehicleRVs.FirstOrDefaultAsyncEF(v => v.Id == newRv.Id);

            if (updateRv == null)
                throw new ArgumentNullException(nameof(updateRv));
            
            updateRv.Image = string.IsNullOrEmpty(newRv.Image) ? updateRv.Image : newRv.Image;
            updateRv.Description = string.IsNullOrEmpty(newRv.Description) ? updateRv.Description : newRv.Description;
            updateRv.Odometer = newRv.Odometer < 1 ? updateRv.Odometer : newRv.Odometer;
            updateRv.GeneratorHours = newRv.GeneratorHours < 1 ? updateRv.GeneratorHours : newRv.GeneratorHours;
            updateRv.FuelLevel = newRv == null ? updateRv.FuelLevel : newRv.FuelLevel;
            updateRv.IsBooked = newRv == null ? updateRv.IsBooked : newRv.IsBooked;
            updateRv.ModifiedOn = DateTime.Now;

            _context.VehicleRVs.Update(updateRv);
            await _context.SaveChangesAsync();
        }
    }
}
