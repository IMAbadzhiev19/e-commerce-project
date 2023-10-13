using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.ECommerce;

/// <summary>
/// A class representing the watchlist
/// </summary>
public class WishlistSercive : IWishlistService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _user;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="user"></param>
    public WishlistSercive(ApplicationDbContext context, UserManager<ApplicationUser> user)
    {
        this._context = context;
        this._user = user;
    }

    /// <inheritdoc/>
    public async Task AddProductToWishlistAsync(string userId, Guid productId, Guid wishlistId)
    {
        var user = _user.FindByIdAsync(userId);
        if (user is null)
        {
            throw new ArgumentException("Invalid userId");
        }

        var wishlist = await this._context.Wishlists.FindAsync(wishlistId);
        if (wishlist is null)
        {
            throw new ArgumentException("Invalid wishlistId");
        }

        var product = await _context.Products.FindAsync(productId);
        if(product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        wishlist.Products.Add(product);
        _context.Wishlists.Update(wishlist);
        await this._context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateWishlistAsync(string userId)
    {
        var user = await _user.FindByIdAsync(userId);
        if (user is null)
        {
            throw new ArgumentException();
        }
        
        var wishlist = new Wishlist
        {
            UserId = userId,
        };

        this._context.Wishlists.Add(wishlist);
        await this._context.SaveChangesAsync();
        return wishlist.Id;
    }

    /// <inheritdoc/>
    public async Task<Wishlist> GetWishlistsAsync(string userId)
    {
        var user = _user.FindByIdAsync(userId);
        if (user is null)
        {
            throw new ArgumentException();
        }

        var wishlist = await this._context.Wishlists.FindAsync(userId);

        if (wishlist is null)
            throw new Exception("Wishlist not found");

        return wishlist;
    }

    /// <inheritdoc/>
    public async Task RemoveProductFromWishlistAsync(string userId, Guid productId, Guid wishlistId)
    {
        var user = _user.FindByIdAsync(userId);
        if (user is null)
        {
            throw new ArgumentException("Invalid userId");
        }

        var wishList = await this._context.Wishlists.FindAsync(wishlistId);
        if (wishList is null)
        {
            throw new ArgumentException("Invalid wishlistId");
        }

        var product = await _context.Products.FindAsync(productId);
        if (product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        wishList.Products.Remove(product);
        _context.Wishlists.Update(wishList);
        await this._context.SaveChangesAsync();
    }
}