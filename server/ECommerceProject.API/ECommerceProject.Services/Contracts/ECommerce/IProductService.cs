using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Shared.Models.ECommerce;
using Microsoft.AspNetCore.Http;

namespace ECommerceProject.Services.Contracts.ECommerce;

public interface IProductService
{
    Task<List<ProductVM>> GetProductsByCategoryAsync(Categories category);

    Task MakeProductRequestAsync(string userId, ProductRM productRM, string? comments);

    Task UploadImageAsync(IFormFile image);
}