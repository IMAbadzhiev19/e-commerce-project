using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Shared.Models.Auth.Token;

namespace ECommerceProject.Services.Contracts.Auth;

public interface ITokenService
{
    Task<Tokens> CreateTokensForUserAsync(string email);

    Task<Tokens> CreateNewTokensAsync(TokensIM tokens);

    Task SaveRefreshTokenAsync(RefreshToken refreshToken);

    Task DeleteRefreshTokenAsync(string userId);

    Task<string> GeneratePasswordResetTokenAsync(string email);
    Task<string> GenerateEmailConfirmationAsync(string email);
}