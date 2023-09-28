using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.WebHost.Extensions;

public static class IdentityConfiguration
{
    public static void AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, IdentityUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequiredLength = 7;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;

            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });
    }
}