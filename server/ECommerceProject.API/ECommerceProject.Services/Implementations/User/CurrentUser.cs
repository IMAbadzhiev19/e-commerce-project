using ECommerceProject.Services.Contracts.User;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerceProject.Services.Implementations.User;

public class CurrentUser : ICurrentUser
{
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor?
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
            .Value!;
    }

    public string UserId { get; }
}
