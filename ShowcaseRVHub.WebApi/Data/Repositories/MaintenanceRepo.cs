using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class MaintenanceRepo : IMaintenance
    {
        private readonly ShowcaseDbContext _context;

        public MaintenanceRepo(ShowcaseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateMaintenanceAsync(RvMaintenance rvMaintenance)
        {
            try
            {
                if (rvMaintenance == null)
                    return false;

                _context.Maintenances.Add(rvMaintenance);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> DeleteMaintenanceAsync(int id)
        {
            try
            {
                RvMaintenance? deleteMain = await _context.Maintenances.FirstOrDefaultAsyncEF(x => x.Id == id);

                if (deleteMain == null)
                    return false;

                _context.Maintenances.Remove(deleteMain);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<RvMaintenance>?> GetMaintenanceAsync()
        {
            try
            {
                List<RvMaintenance> rvMaintenances = await _context.Maintenances
                                                                        .Include(u => u.User)
                                                                        .Include(v => v.Vehicle)
                                                                        .ToListAsync();

                if (!rvMaintenances.Any())
                    return null;

                return rvMaintenances;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<RvMaintenance?> GetMaintenanceByIdAsync(int id)
        {
            try
            {
                RvMaintenance? rvMain = await _context.Maintenances
                                                            .Include(u => u.User)
                                                            .Include(v => v.Vehicle)
                                                            .FirstOrDefaultAsyncEF(x => x.Id == id);

                if (rvMain == null)
                    return null;

                return rvMain;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateMaintenanceAsync(RvMaintenance newRvMaintenance)
        {
            try
            {
                RvMaintenance? rvMain = await _context.Maintenances.FirstOrDefaultAsyncEF(x => x.Id == newRvMaintenance.Id);

                if (rvMain == null)
                    return false;

                RvMaintenance updateRvMain = new RvMaintenance
                {
                    IsTireInspected = newRvMaintenance.IsTireInspected,
                    IsMaintenance = newRvMaintenance.IsMaintenance,
                    IsFluidChecked = newRvMaintenance.IsFluidChecked,
                    IsSystemsChecked = newRvMaintenance.IsSystemsChecked,
                    MaintenanceStart = newRvMaintenance.MaintenanceStart,
                    MaintenanceEnd = newRvMaintenance.MaintenanceEnd,
                    ModifiedOn = DateTime.Now,
                };

                _context.Maintenances.Update(updateRvMain);
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
