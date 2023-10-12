using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Shared.Models.User;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.User;

/// <summary>
/// A class representing the user service
/// </summary>
public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="userManager">UserManager</param>
    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    /// <inheritdoc/>
    public async Task<IdentityResult> ChangePasswordAsync(string userId, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            throw new ArgumentException("Invalid userId");

        var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        return await _userManager.ResetPasswordAsync(user, passwordToken, newPassword);
    }

    /// <inheritdoc/>
    public async Task<bool> CheckPasswordAsync(string userId, string password)
    {
        var user = await _userManager.FindByIdAsync(userId);

        return user is not null && await _userManager.CheckPasswordAsync(user, password);
    }

    /// <inheritdoc/>
    public async Task<(UserVM user, string userId)> GetUserByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new ArgumentException("Invalid id");

        return (user.Adapt<UserVM>(), user.Id);
    }

    /// <inheritdoc/>
    public async Task<UserVM> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user is null)
            throw new ArgumentException("Invalid id");

        return user.Adapt<UserVM>();
    }

    /// <inheritdoc/>
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
