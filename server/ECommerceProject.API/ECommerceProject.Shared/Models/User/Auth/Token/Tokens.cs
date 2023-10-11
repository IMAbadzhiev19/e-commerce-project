using System.IdentityModel.Tokens.Jwt;

namespace ECommerceProject.Shared.Models.User.Auth.Token;

/// <summary>
/// Tokens Model
/// </summary>
public class Tokens
{
    /// <summary>
    /// The Access Token as JwtSecurityToken
    /// </summary>
    public JwtSecurityToken? AccessToken { get; set; } = new();

    /// <summary>
    /// The Refresh Token as JwtSecurityToken
    /// </summary>
    public JwtSecurityToken? RefreshToken { get; set; } = new();
}
