using ECommerceProject.Shared.Models.Auth;

namespace ECommerceProject.Services.Contracts.Auth;

public interface IAuthService
{
    Task CreateUserAsync(RegisterIM registerIM);
}