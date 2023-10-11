using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.WebHost.Extensions;

/// <summary>
/// Identity configuration
/// </summary>
public static class IdentityConfiguration
{
    /// <summary>
    /// Extension method that adds the identity configuration
    /// </summary>
    /// <param name="services">The Service Collector</param>
    public static void AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 1;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;

            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });
    }
}