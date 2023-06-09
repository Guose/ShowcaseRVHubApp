﻿using ShowcaseRVHub.WebApi.Models;

namespace ShowcaseRVHub.WebApi.Data.Interfaces
{
    public interface IRenterRepo
    {
        Task<bool> CreateRenterAsync(ShowcaseRenter renter);
        Task<IEnumerable<ShowcaseRenter>?> GetRentersAsync();
        Task<ShowcaseRenter?> GetRenterByIdAsync(int id);
        Task<bool> UpdateRenterAsync(ShowcaseRenter renter);
        Task<bool> DeleteRenterAsync(int id);
    }
}
