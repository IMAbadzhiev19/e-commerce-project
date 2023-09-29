using ECommerceProject.Services.Contracts;
using ECommerceProject.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.Services;

public static class DependencyInjection
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
    }
}
