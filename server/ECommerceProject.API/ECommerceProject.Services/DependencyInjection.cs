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

/// <summary>
/// Static classed used for Dependency Injection
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// An extension method used for injecting services
    /// </summary>
    /// <param name="services">The service collector</param>
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ICurrentUser, CurrentUser>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IReviewService,ReviewService>();
        services.AddScoped<IWishListService, WishListSercive>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IFileService, FileService>();
    }
}