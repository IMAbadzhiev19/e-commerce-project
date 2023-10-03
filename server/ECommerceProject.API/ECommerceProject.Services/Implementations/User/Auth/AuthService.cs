﻿using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.User.Auth;
using ECommerceProject.Shared.Models.User.Auth;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.User.Auth;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async Task CreateUserAsync(RegisterIM registerIM)
    {
        var user = registerIM.Adapt<ApplicationUser>();
        if (user is null)
            throw new NullReferenceException();

        var result = await _userManager.CreateAsync(user, registerIM.PasswordHash);
        if (!result.Succeeded)
            throw new Exception("User creation failed");
    }
}