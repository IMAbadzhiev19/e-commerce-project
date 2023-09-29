using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.Auth;
using ECommerceProject.Shared.Models.Auth;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.Auth;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;

    public AuthService(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }


    public async Task CreateUserAsync(RegisterIM registerIM)
    {
        var user = registerIM.Adapt<User>();
        if (user is null)
            throw new NullReferenceException();

        var result = await _userManager.CreateAsync(user, registerIM.PasswordHash);
        if (!result.Succeeded)
            throw new Exception("User creation failed");
    }
}