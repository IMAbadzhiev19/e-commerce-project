using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts;
using ECommerceProject.Services.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public AuthService(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async Task CreateUser(RegisterIM registerIM)
    {
        var user = registerIM.Adapt<User>();
        if (user is null)
            throw new NullReferenceException();

        var result = await this._userManager.CreateAsync(user, registerIM.PasswordHash);
        if (!result.Succeeded)
            throw new Exception("User creation failed");
    }
}