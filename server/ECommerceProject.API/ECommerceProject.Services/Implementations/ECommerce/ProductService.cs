using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Services.Implementations.ECommerce;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _context;

    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductVM>> GetProductsByCategoryAsync(Categories category)
    {
        var products = await this._context.Products
        .AsNoTracking()
        .Where(x => x.Category == category)
        .ToListAsync();

        if (products.Count == 0)
            throw new Exception("There are no products within this category");

        return products.Adapt<List<ProductVM>>();
    }

    public Task MakeProductRequestAsync(string userId, ProductRM productRM, string? comments)
    {
        throw new NotImplementedException();
    }

    public Task UploadImageAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }
}