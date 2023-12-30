using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
   public class DepartureRepo : GenericRepository<Departure, ShowcaseDbContext>, IDepartureRepo
   {
        public DepartureRepo(ShowcaseDbContext context) : base(context) {}

        public async Task<DepartureDto?> GetDepartureByIdAsync(int id)
        {
            try
            {
                DepartureDto? departure = await Context.Departures
                                                            .Include(u => u.User)
                                                            .Select(d => new DepartureDto
                                                            {
                                                                Id = d.Id,
                                                                IsExteriorCleaned = d.IsExteriorCleaned,
                                                                IsInteriorCleaned = d.IsInteriorCleaned,
                                                                IsRenterTrained = d.IsRenterTrained,
                                                                IsSignalsChecked = d.IsSignalsChecked,
                                                                CreatedOn = d.CreatedOn,
                                                                FuelLevel = d.FuelLevel,
                                                                BlackWater = d.BlackWater,
                                                                GrayWater = d.GrayWater,
                                                                Propane = d.Propane,
                                                            }).FirstOrDefaultAsyncEF(x => x.Id == id);
                if (departure == null)
                    return null;

                return departure;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<DepartureDto>?> GetDeparturesAsync()
        {
            try
            {
                List<DepartureDto> departures = await Context.Departures
                                                            .Include(u => u.User)
                                                            .Select(d => new DepartureDto
                                                            {
                                                                Id = d.Id,
                                                                IsExteriorCleaned = d.IsExteriorCleaned,
                                                                IsInteriorCleaned = d.IsInteriorCleaned,
                                                                IsRenterTrained = d.IsRenterTrained,
                                                                IsSignalsChecked = d.IsSignalsChecked,
                                                                CreatedOn = d.CreatedOn,
                                                                FuelLevel = d.FuelLevel,
                                                                BlackWater = d.BlackWater,
                                                                GrayWater = d.GrayWater,
                                                                Propane = d.Propane,
                                                            }).ToListAsyncEF();
                if (departures == null)
                    return null;

                return departures;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateDepartureAsync(DepartureDto newDeparture)
        {
            try
            {
                Departure? departure = await Context.Departures.FirstOrDefaultAsyncEF(x => x.Id == newDeparture.Id);

                if (departure == null)
                    return false;

                Departure updateDeparture = new Departure
                {
                    IsExteriorCleaned = newDeparture.IsExteriorCleaned,
                    IsInteriorCleaned = newDeparture.IsInteriorCleaned,
                    IsSignalsChecked = newDeparture.IsSignalsChecked,
                    IsRenterTrained = newDeparture.IsRenterTrained,
                    FuelLevel = newDeparture.FuelLevel,
                    BlackWater = newDeparture.BlackWater,
                    GrayWater = newDeparture.GrayWater,
                    Propane = newDeparture.Propane,
                    ModifiedOn = DateTime.Now,
                };

                Context.Departures.Update(updateDeparture);
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
