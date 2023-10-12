using ECommerceProject.Services.Contracts.User;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerceProject.Services.Implementations.User;

/// <summary>
/// A class representing the current user
/// </summary>
public class CurrentUser : ICurrentUser
{
    /// <summary>
    /// A constructor used for injecting the dependencies and setting up the UserId
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor?
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
            .Value!;
    }

    /// <inheritdoc/>
    public string UserId { get; }
}
