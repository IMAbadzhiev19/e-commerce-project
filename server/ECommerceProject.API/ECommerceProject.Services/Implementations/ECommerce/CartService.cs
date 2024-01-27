using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Services.Implementations.ECommerce;

/// <summary>
/// The class containing the implementations of the ICartService interface
/// </summary>
public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// The constructor used for injecting services
    /// </summary>
    /// <param name="context">DBContext</param>
    /// <param name="userManager">UserManager</param>
    public CartService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    /// <inheritdoc/>
    public async Task AddProductToCartAsync(Guid productId, Guid cartId)
    {
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

    /// <inheritdoc/>
    public async Task<Guid> CreateCartAsync(string userId)
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

    /// <inheritdoc/>
    public async Task<CartVM> GetCartByIdAsync(string userId)
    {
        var cart = await this._context.Carts.Where(x => x.UserId == userId && x.IsActive == true).Include(c => c.Products)
            .FirstOrDefaultAsync();

        if (cart == null)
        {
            await CreateCartAsync(userId);
            cart = await this._context.Carts.Include(c => c.Products).Where(x => x.UserId == userId && x.IsActive == true)
            .FirstOrDefaultAsync();
        }

        if (cart is null)
            throw new Exception("An error occured while retrieving the cart");

        return cart.Adapt<CartVM>();
    }

    /// <inheritdoc/>
    public async Task RemoveProductFromCartAsync(Guid productId, Guid cartId)
    {
        var product = await this._context.Products
            .FindAsync(productId);

        if (product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        var cart = await this._context.Carts
            .Where(c => c.Id == cartId)
            .Include(c => c.Products)
            .FirstOrDefaultAsync();

        if (cart is null)
        {
            throw new ArgumentException("Invalid cartId");
        }

        cart.Products.Remove(product);
        await this._context.SaveChangesAsync();
    }
}