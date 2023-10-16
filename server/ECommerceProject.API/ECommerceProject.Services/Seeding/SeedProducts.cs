using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceProject.WebHost.Seeding;

/// <summary>
/// A static class storing a seeding method
/// </summary>
public static class SeedProducts
{
    /// <summary>
    /// A static method used for seeding products into the database
    /// </summary>
    public static async Task SeedProductsAsync(IServiceProvider serviceProvider)
    {
        var productService = serviceProvider.GetRequiredService<IProductService>();


        if ((await productService.GetProductsByCategoryAsync(Categories.None)).Count == 0)
        {
            var products = new List<ProductIM>();

            await productService.AddProductsAsync(products);
        }
    }
}