namespace ECommerceProject.Shared.Models.User.Auth.Token;

/// <summary>
/// Tokens Input Model
/// </summary>
public class TokensIM
{
    /// <summary>
    /// The Access Token
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;
    
    /// <summary>
    /// The Refresh Token
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;
}
