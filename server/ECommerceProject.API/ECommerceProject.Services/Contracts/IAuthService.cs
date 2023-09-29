using ECommerceProject.Services.Models;

namespace ECommerceProject.Services.Contracts;

public interface IAuthService
{
    Task CreateUser(RegisterIM registerIM);
}