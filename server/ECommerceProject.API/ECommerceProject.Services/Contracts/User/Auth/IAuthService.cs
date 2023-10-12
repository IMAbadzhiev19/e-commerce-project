using ECommerceProject.Shared.Models.User.Auth;

namespace ECommerceProject.Services.Contracts.User.Auth;

/// <summary>
/// Interface representing an authentication service.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Asynchronously create a new user based on the provided registration input model.
    /// </summary>
    /// <param name="registerIM">The registration input model with user details.</param>
    Task CreateUserAsync(RegisterIM registerIM);

    /// <summary>
    /// Asynchronously grant administrator privileges to a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to promote to an admin.</param>
    Task MakeAdminAsync(string userId);
}