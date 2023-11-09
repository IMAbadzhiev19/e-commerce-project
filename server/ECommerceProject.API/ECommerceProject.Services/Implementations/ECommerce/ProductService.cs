using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Services.Contracts;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Services.Implementations.ECommerce;

/// <summary>
/// A class representing the product service
/// </summary>
public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userManager"></param>
    public ProductService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    /// <inheritdoc/>
    public async Task<ProductVM> GetProductByIdAsync(Guid productId)
    {
        var product = await this._context.Products
            .FindAsync(productId);

        if (product is null)
            throw new ArgumentException("Invalid productId");

        return product.Adapt<ProductVM>();
    }

    /// <inheritdoc/>
    public async Task<ICollection<ProductVM>> GetProductsByCategoryAsync(Categories category)
    {
        List<Product> products;
        if (category is Categories.None)
        {
            products = await this._context.Products
                .AsNoTracking()
                .ToListAsync();
        }
        else
        {
            products = await this._context.Products
                .AsNoTracking()
                .Where(p => p.Category == category)
                .ToListAsync();
        }

        if (products.Count == 0)
            return new List<ProductVM>();

        return products.Adapt<List<ProductVM>>();
    }

    /// <inheritdoc/>
    public async Task UpdateProductAsync(Guid productId, ProductUM newProduct)
    {
        var product = await this._context.Products.FindAsync(productId);
        if (product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        if (newProduct.Title != null)
            product.Title = newProduct.Title;
        if (newProduct.Price != null)
            product.Price = (decimal)newProduct.Price;
        if (newProduct.Description != null)
            product.Description = newProduct.Description;
        if (newProduct.ImageUrl != null)
            product.ImageUrl = newProduct.ImageUrl;
        if (newProduct.Quantity != null)
            product.Quantity = newProduct.Quantity;

        await this._context.SaveChangesAsync();
    }

<<<<<<< HEAD
    public async Task<ICollection<ProductVM>> GetProducts()
    {
        var products = await this._context.Products.ToListAsync();

        if(products is null)
        {
            throw new ArgumentException("NULL");
        }

        return products.Adapt<List<ProductVM>>();
=======
    /// <inheritdoc/>
    public async Task AddProductsAsync(ICollection<ProductIM> products)
    {
        foreach(var product in products)
        {
            await this._context.Products
                .AddAsync(product.Adapt<Product>());
        }

        await this._context.SaveChangesAsync();
>>>>>>> d43f027a62472554b881294057529ac59b4514ad
    }
}