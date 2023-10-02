using ECommerceProject.Shared.Models.User;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Contracts.User;

public interface IUserService
{
    Task<UserVM> GetUserByIdAsync(string userId);

    Task<IdentityResult> ChangePasswordAsync(string userId, string newPassword);

    Task<bool> CheckPasswordAsync(string userId, string password);

    Task UpdateUserInfoAsync(string userId, UserIM userIM);

    Task<(UserVM user, string userId)> GetUserByEmailAsync(string email);
}
