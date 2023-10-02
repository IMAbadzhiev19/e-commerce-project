using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Shared.Models.User;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.User;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> ChangePasswordAsync(string userId, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            throw new ArgumentException("Invalid userId");

        var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        return await _userManager.ResetPasswordAsync(user, passwordToken, newPassword);
    }

    public async Task<bool> CheckPasswordAsync(string userId, string password)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return user is not null && await _userManager.CheckPasswordAsync(user, password);
    }

    public async Task<(UserVM user, string userId)> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new ArgumentException("Invalid id");

        return (user.Adapt<UserVM>(), user.Id);
    }

    public async Task<UserVM> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            throw new ArgumentException("Invalid id");

        return user.Adapt<UserVM>();
    }

    public async Task UpdateUserInfoAsync(string userId, UserIM userIM)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            throw new ArgumentException("Invalid userId");

        user.UserName = userIM.UserName;
        user.FirstName = userIM.FirstName;
        user.LastName = userIM.LastName;
        user.Email = userIM.Email;
        user.PhoneNumber = userIM.PhoneNumber;

        await _userManager.UpdateAsync(user);
    }
}
