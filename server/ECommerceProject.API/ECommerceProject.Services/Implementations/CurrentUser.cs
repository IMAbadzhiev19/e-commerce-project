using ECommerceProject.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ECommerceProject.Services.Implementations;

public class CurrentUser : ICurrentUser
{
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        this.UserId = httpContextAccessor?
            .HttpContext?
            .User?
            .Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
            .Value!;
    }

    public string UserId { get; }
}
