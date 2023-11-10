using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Shared.Models.ECommerce;
using Microsoft.AspNetCore.Http;

namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Interface representing a service for managing products.
/// </summary>
public interface IProductService
{
    /// <summary>
    /// Get a collection of products within a specified category.
    /// </summary>
    /// <param name="category">The category to filter products by.</param>
    /// <returns>Task representing a collection of products view models.</returns>
    Task<ICollection<ProductVM>> GetProductsByCategoryAsync(Categories category);

    //Task MakeProductRequestAsync(string userId, ProductRM productRM, string? comments);

    /// <summary>
    /// Update an existing product with new information.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to update.</param>
    /// <param name="newProduct">The updated product data.</param>
    /// <returns>Task representing the update operation.</returns>
    Task UpdateProductAsync(Guid productId, ProductUM newProduct);

    /// <summary>
    /// Get a product by its unique identitifer
    /// </summary>
    /// <param name="productId">The unique identifier of the product</param>
    /// <returns>Product View Model</returns>
    Task<ProductVM> GetProductByIdAsync(Guid productId);

    Task<ICollection<ProductVM>> GetProducts();
    /// <summary>
    /// Adds a collection of products to the database
    /// </summary>
    /// <param name="products">The collection of products to be added</param>
    Task AddProductsAsync(ICollection<ProductIM> products);
}