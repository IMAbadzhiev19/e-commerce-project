using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.Auth;
using ECommerceProject.Shared.Models.Auth.Token;
using ECommerceProject.Shared.Models.Auth.Token.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerceProject.Services.Implementations.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;
    
    public TokenService(IConfiguration config, UserManager<User> userManager, ApplicationDbContext context)
    {
        _config = config;
        _userManager = userManager;
        _context = context;
    }


    public Task<Tokens> CreateNewTokensAsync(TokensIM tokens)
    {
        throw new NotImplementedException();
    }

    public async Task<Tokens> CreateTokensForUserAsync(string email)
    {
        var user = await this._userManager.FindByEmailAsync(email);

        if (user is null)
            throw new ArgumentException("Invalid email");

        var userRoles = await this._userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        foreach (var userRole in userRoles)
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));

        var accessToken = this.CreateToken(authClaims, TokenTypes.AccessToken);
        var refreshToken = this.CreateToken(authClaims, TokenTypes.RefreshToken);

        await this.SaveRefreshTokenAsync(new RefreshToken
        {
            Token = new JwtSecurityTokenHandler().WriteToken(refreshToken),
            UserId = user.Id,
        });

        return new()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };
    }

    public Task DeleteRefreshTokenAsync(RefreshToken refreshToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GenerateEmailConfirmationAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<string> GeneratePasswordResetTokenAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task SaveRefreshTokenAsync(RefreshToken refreshToken)
    {
        await this._context.AddAsync(refreshToken);
        await this._context.SaveChangesAsync();
    }


    //Helpers
    private JwtSecurityToken CreateToken(List<Claim> authClaims, TokenTypes tokenType)
    {
        SymmetricSecurityKey? signingKey;
        int tokenValidity = 0;

        if (tokenType == TokenTypes.AccessToken)
        {
            signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config["JWT:Secret"]!));
            _ = int.TryParse(this._config["JWT:AccessTokenValidity"], out tokenValidity);
        }
        else
        {
            signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._config["JWT:RefreshTokenSecret"]!));
            _ = int.TryParse(this._config["JWT:RefreshTokenValidity"], out tokenValidity);
        }

        var token = new JwtSecurityToken(
            expires: tokenType == TokenTypes.AccessToken ? DateTime.UtcNow.AddMinutes(tokenValidity) : DateTime.UtcNow.AddDays(tokenValidity),
            claims: authClaims,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }
}