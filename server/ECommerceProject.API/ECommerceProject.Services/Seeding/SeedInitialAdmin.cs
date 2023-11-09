using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.User.Auth;
using ECommerceProject.Shared.Models.User.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.WebHost.Seeding;

/// <summary>
/// A static class storing a seeding method
/// </summary>
public static class SeedInitialAdmin
{
    /// <summary>
    /// A static method used for initializing a default admin to the database
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="serviceProvider"></param>
    /// <returns></returns>
    public static async Task SeedInitialAdminAsync(IConfiguration configuration, IServiceProvider serviceProvider)
    {
        var authService = serviceProvider.GetRequiredService<IAuthService>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync(UserRoles.User) && !await roleManager.RoleExistsAsync(UserRoles.Admin))
        {
            var userId = await authService.CreateUserAsync(
                new RegisterIM
                {
                    UserName = configuration["InitialAdmin:UserName"]!,
                    Email = configuration["InitialAdmin:Email"]!,
                    Address = new Address
                    {
                        Street = "N/A",
                        City = "N/A",
                        Region = "N/A",
                    },
                    PasswordHash = configuration["InitialAdmin:Password"]!,
                });

            await authService.MakeAdminAsync(userId);
        }
    }
}