﻿using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.User.Auth;
using ECommerceProject.Shared.Models.User.Auth;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.User.Auth;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }


    public async Task CreateUserAsync(RegisterIM registerIM)
    {
        if (!await this._roleManager.RoleExistsAsync(UserRoles.User))
            await this._roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        var user = registerIM.Adapt<ApplicationUser>();
        if (user is null)
            throw new NullReferenceException();

        var result = await _userManager.CreateAsync(user, registerIM.PasswordHash);
        if (!result.Succeeded)
            throw new Exception("User creation failed");

        var roleResult = await _userManager.AddToRoleAsync(user, UserRoles.User);
        if (!roleResult.Succeeded)
            throw new Exception("Adding role failed");
    }

    public async Task MakeAdminAsync(string userId)
    {
        if (!await this._roleManager.RoleExistsAsync(UserRoles.Admin))
            await this._roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

        var user = await this._userManager.FindByIdAsync(userId);
        if (user is null)
            throw new ArgumentException("Invalid userId");
        
        var result = await this._userManager.AddToRoleAsync(user, UserRoles.Admin);
        if (!result.Succeeded)
            throw new Exception("Adding user to admin role failed");
    }
}