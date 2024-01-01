using LinqToDB;
using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class MaintenanceRepo : GenericRepository<RvMaintenance, ShowcaseDbContext>, IMaintenance
    {
        public MaintenanceRepo(ShowcaseDbContext context) : base(context) {}
        public async Task<IEnumerable<RvMaintenanceDto>?> GetMaintenanceAsync()
        {
            try
            {
                List<RvMaintenanceDto> rvMaintenances = await Context.Maintenances
                                                                        .Include(v => v.Vehicle)
                                                                        .Select(m => new RvMaintenanceDto
                                                                        {
                                                                            Id = m.Id,
                                                                            IsFluidChecked = m.IsFluidChecked,
                                                                            IsMaintenance = m.IsMaintenance,
                                                                            IsSystemsChecked = m.IsSystemsChecked,
                                                                            IsTireInspected = m.IsTireInspected,
                                                                            CreatedOn = m.CreatedOn,
                                                                            MaintenanceStart = m.MaintenanceStart,
                                                                            MaintenanceEnd = m.MaintenanceEnd,
                                                                        }).ToListAsyncEF();

                if (!rvMaintenances.Any())
                    return null;

                return rvMaintenances;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<RvMaintenanceDto?> GetMaintenanceByIdAsync(int id)
        {
            try
            {
                RvMaintenanceDto? rvMain = await Context.Maintenances
                                                            .Include(u => u.User)
                                                            .Include(v => v.Vehicle)
                                                            .Select(m => new RvMaintenanceDto
                                                            {
                                                                Id = m.Id,
                                                                IsFluidChecked = m.IsFluidChecked,
                                                                IsMaintenance = m.IsMaintenance,
                                                                IsSystemsChecked = m.IsSystemsChecked,
                                                                IsTireInspected = m.IsTireInspected,
                                                                CreatedOn = m.CreatedOn,
                                                                MaintenanceStart = m.MaintenanceStart,
                                                                MaintenanceEnd = m.MaintenanceEnd,
                                                            }).FirstOrDefaultAsyncEF(x => x.Id == id);

                if (rvMain == null)
                    return null;

                return rvMain;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateMaintenanceAsync(RvMaintenanceDto newRvMaintenance)
        {
            try
            {
                RvMaintenance? rvMain = await Context.Maintenances.FirstOrDefaultAsyncEF(x => x.Id == newRvMaintenance.Id);

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

                Context.Maintenances.Update(updateRvMain);
                await SaveAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
