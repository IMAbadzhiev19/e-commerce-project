using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Shared.Models.User.Auth.Token;

namespace ECommerceProject.Services.Contracts.User.Auth;

public interface ITokenService
{
    Task<Tokens> CreateTokensForUserAsync(string email);

    Task<Tokens> CreateNewTokensAsync(TokensIM tokens);

    Task SaveRefreshTokenAsync(RefreshToken refreshToken);

    Task DeleteRefreshTokenAsync(string userId);

    Task<string> GeneratePasswordResetTokenAsync(string email);
    Task<string> GenerateEmailConfirmationAsync(string email);
}