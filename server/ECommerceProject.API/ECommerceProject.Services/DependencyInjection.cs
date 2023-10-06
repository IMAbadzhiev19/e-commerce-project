using ECommerceProject.Services.Contracts;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Services.Contracts.User.Auth;
using ECommerceProject.Services.Implementations;
using ECommerceProject.Services.Implementations.ECommerce;
using ECommerceProject.Services.Implementations.User;
using ECommerceProject.Services.Implementations.User.Auth;
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
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IFileService, FileService>();
    }
}