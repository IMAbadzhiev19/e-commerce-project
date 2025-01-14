﻿using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ECommerceProject.Services.Contracts.User.Auth;
using ECommerceProject.Shared.Models.User.Auth.Token;
using ECommerceProject.Shared.Models.User.Auth.Token.Enums;

namespace ECommerceProject.Services.Implementations.User.Auth;

/// <summary>
/// A class representing the token service
/// </summary>
public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="config"></param>
    /// <param name="userManager"></param>
    /// <param name="context"></param>
    public TokenService(IConfiguration config, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _config = config;
        _userManager = userManager;
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<Tokens> CreateNewTokensAsync(TokensIM tokens)
    {
        var principals = GetPrincipalsFromExpiredToken(tokens.AccessToken);
        if (principals is null)
            throw new ArgumentException("Invalid access token");

        var user = await _userManager.FindByIdAsync(principals.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
        var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == tokens.RefreshToken);

        if (user is null || refreshToken is null || !ValidateRefreshToken(tokens.RefreshToken))
            throw new ArgumentException("Invalid refreshToken");

        await this.DeleteRefreshTokenAsync(user.Id);
        var newRefreshToken = CreateToken(principals.Claims.ToList(), TokenTypes.RefreshToken);

        await SaveRefreshTokenAsync(new RefreshToken
        {
            Token = new JwtSecurityTokenHandler().WriteToken(newRefreshToken),
            UserId = user.Id,
        });

        return new()
        {
            AccessToken = CreateToken(principals.Claims.ToList(), TokenTypes.AccessToken),
            RefreshToken = newRefreshToken,
        };
    }

    /// <inheritdoc/>
    public async Task<Tokens> CreateTokensForUserAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new ArgumentException("Invalid email");

        var userRoles = await _userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
        };

        foreach (var userRole in userRoles)
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));

        var accessToken = CreateToken(authClaims, TokenTypes.AccessToken);
        var refreshToken = CreateToken(authClaims, TokenTypes.RefreshToken);

        if (!_context.RefreshTokens.Any(x => x.UserId == user.Id))
        {
            await SaveRefreshTokenAsync(new RefreshToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(refreshToken),
                UserId = user.Id,
            });
        }
        else
        {
            if (accessToken.ValidTo < DateTime.Now)
                throw new Exception("User is already logged in");
            refreshToken = null;
        }

        return new()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
        };
    }

    /// <inheritdoc/>
    public async Task DeleteRefreshTokenAsync(string userId)
    {
        var refreshToken = await _context
                                    .RefreshTokens
                                    .FirstOrDefaultAsync(x => x.UserId == userId);
        if (refreshToken is null)
            throw new ArgumentException("Invalid userId");

        _context.Remove(refreshToken);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public Task<string> GenerateEmailConfirmationAsync(string email)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<string> GeneratePasswordResetTokenAsync(string email)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task SaveRefreshTokenAsync(RefreshToken refreshToken)
    {
        await _context.AddAsync(refreshToken);
        await _context.SaveChangesAsync();
    }


    /// <summary>
    /// Create a JWT token with the provided claims and token type.
    /// </summary>
    /// <param name="authClaims">A list of claims to include in the token.</param>
    /// <param name="tokenType">The type of token (access or refresh).</param>
    /// <returns>The created JWT token.</returns>

    private JwtSecurityToken CreateToken(List<Claim> authClaims, TokenTypes tokenType)
    {
        SymmetricSecurityKey? signingKey;
        int tokenValidity = 0;

        if (tokenType == TokenTypes.AccessToken)
        {
            signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
            _ = int.TryParse(_config["JWT:AccessTokenValidity"], out tokenValidity);
        }
        else
        {
            signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:RefreshTokenSecret"]!));
            _ = int.TryParse(_config["JWT:RefreshTokenValidity"], out tokenValidity);
        }

        var token = new JwtSecurityToken(
            expires: tokenType == TokenTypes.AccessToken ? DateTime.UtcNow.AddMinutes(tokenValidity) : DateTime.UtcNow.AddDays(tokenValidity),
            claims: authClaims,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    /// <summary>
    /// Extract and validate claims from an expired JWT token.
    /// </summary>
    /// <param name="token">The expired JWT token to validate.</param>
    /// <returns>A ClaimsPrincipal containing validated claims, or null if validation fails.</returns>

    private ClaimsPrincipal? GetPrincipalsFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }

    /// <summary>
    /// Validate the format and integrity of a refresh token.
    /// </summary>
    /// <param name="refreshToken">The refresh token to validate.</param>
    /// <returns>True if the token is valid; otherwise, false.</returns>
    private bool ValidateRefreshToken(string refreshToken)
    {
        var tokenValidationParameter = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:RefreshTokenSecret"]!)),
            ValidateLifetime = false,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        _ = tokenHandler.ValidateToken(refreshToken, tokenValidationParameter, out securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken
            || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            return false;
        }

        return true;
    }
}