﻿using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IShowcaseUserDataService
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(Guid id);
    }
}
