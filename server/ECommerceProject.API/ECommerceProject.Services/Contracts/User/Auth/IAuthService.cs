using ECommerceProject.Shared.Models.User.Auth;

namespace ECommerceProject.Services.Contracts.User.Auth;

public interface IAuthService
{
    Task CreateUserAsync(RegisterIM registerIM);

    Task MakeAdminAsync(string userId);
}