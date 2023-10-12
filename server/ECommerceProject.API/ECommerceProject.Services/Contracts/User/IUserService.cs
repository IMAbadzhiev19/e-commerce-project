using ECommerceProject.Shared.Models.User;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Contracts.User;

/// <summary>
/// Interface representing a service for managing user-related operations.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Asynchronously retrieve a user by their unique identifier.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve.</param>
    /// <returns>A user view model representing the requested user.</returns>
    Task<UserVM> GetUserByIdAsync(string userId);

    /// <summary>
    /// Asynchronously change a user's password.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose password to change.</param>
    /// <param name="newPassword">The new password for the user.</param>
    /// <returns>An IdentityResult representing the result of the password change operation.</returns>
    Task<IdentityResult> ChangePasswordAsync(string userId, string newPassword);

    /// <summary>
    /// Asynchronously check a user's password for validation.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <param name="password">The password to check.</param>
    /// <returns>True if the password is valid; otherwise, false.</returns>
    Task<bool> CheckPasswordAsync(string userId, string password);

    /// <summary>
    /// Asynchronously update user information.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to update.</param>
    /// <param name="userIM">The user input model with updated user information.</param>
    Task UpdateUserInfoAsync(string userId, UserIM userIM);

    /// <summary>
    /// Asynchronously retrieve a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>A tuple containing the user view model and the unique identifier of the requested user.</returns>
    Task<(UserVM user, string userId)> GetUserByEmailAsync(string email);
}
