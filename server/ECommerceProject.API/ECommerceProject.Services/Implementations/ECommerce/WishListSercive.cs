using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
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
    public async Task AddProductToWishlist(string userId, Guid productId, Guid wishListId)
    {
        var user = _user.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ArgumentException();
        }

        var wishList = await this._context.Wishlists.FindAsync(wishListId);
        if (wishList == null)
        {
            throw new ArgumentException();
        }

        var product = await _context.Products.FindAsync(productId);
        if(product == null)
        {
            throw new ArgumentException();
        }

        wishList.Products.Add(product);
        _context.Wishlists.Update(wishList);
        await this._context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateWishlist(string userId)
    {
        var user = await _user.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ArgumentException();
        }

        Wishlist wishlist = new Wishlist()
        {
            UserId = userId,
        };

        this._context.Wishlists.Add(wishlist);
        await this._context.SaveChangesAsync();
        return wishlist.Id;
    }

    /// <inheritdoc/>
    public async Task<Wishlist> GetWishlists(string userId)
    {
        var user = _user.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ArgumentException();
        }

        var wishlist = await this._context.Wishlists.FindAsync(userId);
        return wishlist;
    }

    /// <inheritdoc/>
    public async Task RemoveProductFromWishlist(string userId, Guid productId, Guid wishListId)
    {
        var user = _user.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ArgumentException();
        }

        var wishList = await this._context.Wishlists.FindAsync(wishListId);
        if (wishList == null)
        {
            throw new ArgumentException();
        }

        var product = await _context.Products.FindAsync(productId);
        if (product == null)
        {
            throw new ArgumentException();
        }

        wishList.Products.Remove(product);
        _context.Wishlists.Update(wishList);
        await this._context.SaveChangesAsync();
    }
}