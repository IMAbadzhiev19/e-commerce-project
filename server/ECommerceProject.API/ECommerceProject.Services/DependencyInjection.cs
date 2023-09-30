using ECommerceProject.Services.Contracts;
using ECommerceProject.Services.Contracts.Auth;
using ECommerceProject.Services.Implementations;
using ECommerceProject.Services.Implementations.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.Services;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddScoped<IUserService, UserService>();
    }
}