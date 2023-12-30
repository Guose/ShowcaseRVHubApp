using LinqToDB.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShowcaseRVHub.WebApi.Data.Interfaces;
using ShowcaseRVHub.WebApi.DTOs;
using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Repositories
{
    public class ArrivalRepo : GenericRepository<Arrival, ShowcaseDbContext>, IArrivalRepo
    {
        public ArrivalRepo(ShowcaseDbContext context) : base(context) {}

        public async Task<ArrivalDto?> GetArrivalByIdAsync(int id)
        {
            try
            {
                ArrivalDto? arrival = await Context.Arrivals
                                                        .Include(u => u.User)
                                                        .Select(a => new ArrivalDto
                                                        {
                                                            Id = a.Id,
                                                            IsExteriorCleaned = a.IsExteriorCleaned,
                                                            IsInteriorCleaned = a.IsInteriorCleaned,
                                                            IsSignalsChecked = a.IsSignalsChecked,
                                                            IsCheckInComplete = a.IsCheckInComplete,
                                                            CreatedOn = a.CreatedOn,
                                                            FuelLevel = a.FuelLevel,
                                                            BlackWater = a.BlackWater,
                                                            GrayWater = a.GrayWater,
                                                            Propane = a.Propane,
                                                        }).FirstOrDefaultAsyncEF(x => x.Id == id);
                if (arrival == null)
                    return null;

                return arrival;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<ArrivalDto>?> GetArrivalsAsync()
        {
            try
            {
                List<ArrivalDto> arrivals = await Context.Arrivals
                                                            .Include(u => u.User)
                                                            .Select(a => new ArrivalDto
                                                            {
                                                                Id = a.Id,
                                                                IsExteriorCleaned = a.IsExteriorCleaned,
                                                                IsInteriorCleaned = a.IsInteriorCleaned,
                                                                IsSignalsChecked = a.IsSignalsChecked,
                                                                IsCheckInComplete = a.IsCheckInComplete,
                                                                CreatedOn = a.CreatedOn,
                                                                FuelLevel = a.FuelLevel,
                                                                BlackWater = a.BlackWater,
                                                                GrayWater = a.GrayWater,
                                                                Propane = a.Propane,
                                                            }).ToListAsyncEF();
                if (arrivals == null)
                    return null;

                return arrivals;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<bool> UpdateArrivalAsync(ArrivalDto newArrival)
        {
            try
            {
                Arrival? arrival = await Context.Arrivals.FirstOrDefaultAsyncEF(a => a.Id == newArrival.Id);

                if (arrival == null) 
                    return false;

                Arrival updateArrival = new Arrival
                {
                    IsExteriorCleaned = newArrival.IsExteriorCleaned,
                    IsInteriorCleaned = newArrival.IsInteriorCleaned,
                    IsSignalsChecked = newArrival.IsSignalsChecked,
                    IsCheckInComplete = newArrival.IsCheckInComplete,
                    FuelLevel = newArrival.FuelLevel,
                    BlackWater = newArrival.BlackWater,
                    GrayWater = newArrival.GrayWater,
                    Propane = newArrival.Propane,
                    ModifiedOn = DateTime.Now,
                };


                Context.Arrivals.Update(updateArrival);
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
