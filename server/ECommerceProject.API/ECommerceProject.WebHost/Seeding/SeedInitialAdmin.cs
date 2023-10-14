using ECommerceProject.Data.Models.Auth;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.WebHost.Seeding;

public static class SeedInitialAdmin
{

    public static async Task SeedInitialAdminAsync(IConfiguration configuration, IServiceProvider serviceProvider)
    {        
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync(UserRoles.User) && !await roleManager.RoleExistsAsync(UserRoles.Admin))
        {            
            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));


            var user = new ApplicationUser
            {
                UserName = configuration["InitialAdmin:UserName"],
                Email = configuration["InitialAdmin:Email"],
                Address = new Address
                {
                  Street = "N/A",
                  City = "N/A",
                  Region = "N/A",
                },
            };

            var userResult = await userManager.CreateAsync(user, configuration["InitialAdmin:Password"]!);
            if (!userResult.Succeeded)
                throw new Exception("User creation failed");

            var roleResult = await userManager.AddToRoleAsync(user, UserRoles.User);
            if (!roleResult.Succeeded)
                throw new Exception("Adding user role failed");

            roleResult = await userManager.AddToRoleAsync(user, UserRoles.Admin);
            if (!roleResult.Succeeded)
                throw new Exception("Adding admin role failed");
        }
    }
}