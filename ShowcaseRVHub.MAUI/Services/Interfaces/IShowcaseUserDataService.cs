﻿using ShowcaseRVHub.MAUI.Model;

namespace ShowcaseRVHub.MAUI.Services.Interfaces
{
    public interface IShowcaseUserDataService
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserModel user);
        Task UpdateUserAsync(UserModel user);
        Task UpdateUsersEmailAsync(Guid id, string email);
        Task DeleteUserAsync(Guid id);
    }
}
