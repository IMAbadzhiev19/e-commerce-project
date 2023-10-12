using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Shared.Models.User.Auth.Token;

namespace ECommerceProject.Services.Contracts.User.Auth;

/// <summary>
/// Interface representing a service for token management and generation.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Asynchronously create authentication tokens for a user based on their email.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>Tokens containing access and refresh tokens.</returns>
    Task<Tokens> CreateTokensForUserAsync(string email);

    /// <summary>
    /// Asynchronously create new tokens based on a token input model.
    /// </summary>
    /// <param name="tokens">The token input model.</param>
    /// <returns>Tokens containing access and refresh tokens.</returns>
    Task<Tokens> CreateNewTokensAsync(TokensIM tokens);

    /// <summary>
    /// Asynchronously save a refresh token for a user.
    /// </summary>
    /// <param name="refreshToken">The refresh token to save.</param>
    Task SaveRefreshTokenAsync(RefreshToken refreshToken);

    /// <summary>
    /// Asynchronously delete a user's refresh token.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    Task DeleteRefreshTokenAsync(string userId);

    /// <summary>
    /// Asynchronously generate a password reset token for a user based on their email.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The password reset token.</returns>
    Task<string> GeneratePasswordResetTokenAsync(string email);

    /// <summary>
    /// Asynchronously generate an email confirmation token for a user based on their email.
    /// </summary>
    /// <param name="email">The email address of the user.</param>
    /// <returns>The email confirmation token.</returns>
    Task<string> GenerateEmailConfirmationAsync(string email);
}