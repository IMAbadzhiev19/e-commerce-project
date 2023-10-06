using ECommerceProject.Shared.Models.ECommerce;

namespace ECommerceProject.Services.Contracts;

public interface IEmailService
{
    Task SendProductRequest(ProductRM productRM);
}