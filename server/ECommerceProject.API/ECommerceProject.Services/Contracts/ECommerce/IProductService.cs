using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Shared.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

public interface IProductService
{
    Task<List<ProductVM>> GetProductsByCategoryAsync(Categories category, params Filters[] filters);

    Task MakeProductRequestAsync(string userId, ProductRM productRM, string? comments);
}