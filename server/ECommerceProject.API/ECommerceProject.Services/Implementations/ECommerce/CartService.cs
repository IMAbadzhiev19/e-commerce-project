using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.ECommerce;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public CartService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task AddProductToCart(string userId, Guid productId, Guid cartId)
    {
        var user = await this._userManager.FindByIdAsync(userId);

        if (user is null)
        {
            throw new ArgumentException("Invalid userId");
        }

        var product = await this._context.Products
            .FindAsync(productId);

        if (product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        var cart = await this._context.Carts
            .FindAsync(cartId);
        
        if (cart is null)
        {
            throw new ArgumentException("Invalid cartId");
        }

        cart.Products.Add(product);
        await this._context.SaveChangesAsync();
    }

    public async Task<Guid> CreateCart(string userId)
    {
        var user = await this._userManager.FindByIdAsync(userId);

        if (user is null)
        {
            throw new ArgumentException("Invalid userId");
        }

        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Products = new List<Product>(),
        };

        await this._context.AddAsync(cart);
        await this._context.SaveChangesAsync();

        return cart.Id;
    }

    public Task ProceedToCheckout(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveProductFromCart(string userId, Guid productId, Guid cartId)
    {
        var user = await this._userManager.FindByIdAsync(userId);

        if (user is null)
        {
            throw new ArgumentException("Invalid userId");
        }

        var product = await this._context.Products
            .FindAsync(productId);

        if (product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        var cart = await this._context.Carts
            .FindAsync(cartId);

        if (cart is null)
        {
            throw new ArgumentException("Invalid cartId");
        }

        cart.Products.Remove(product);
        await this._context.SaveChangesAsync();
    }
}