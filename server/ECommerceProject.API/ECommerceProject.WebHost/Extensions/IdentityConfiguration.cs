using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.WebHost.Extensions;

public static class IdentityConfiguration
{
    public static void AddIdentity(this IServiceCollection services)
    {
        services
            .AddIdentity<User, IdentityRole>()
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