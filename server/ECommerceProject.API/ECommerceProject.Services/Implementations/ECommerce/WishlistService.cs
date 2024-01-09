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
/// A class representing the watchlist
/// </summary>
public class WishlistService : IWishlistService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="user"></param>
    public WishlistService(ApplicationDbContext context, UserManager<ApplicationUser> user)
    {
        this._context = context;
        this._userManager = user;
    }

    /// <inheritdoc/>
    public async Task AddProductToWishlistAsync(string userId, Guid productId, Guid wishlistId)
    {
        var user = _userManager.FindByIdAsync(userId);
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
        var user = await _userManager.FindByIdAsync(userId);
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
    public async Task<WishlistVM> GetWishlistByIdAsync(string userId)
    {
        var wishlist = await this._context.Wishlists.Include(w => w.Products)
            .Where(w => w.UserId == userId).FirstOrDefaultAsync();

        if (wishlist is null)
            throw new ArgumentException("Invalid wishlistId");

        if (wishlist.UserId != userId)
            throw new Exception("The wishlist does not belong to you");

        return wishlist.Adapt<WishlistVM>();
    }

    /// <inheritdoc/>
    //public async Task<ICollection<WishlistVM>> GetWishlistsAsync(string userId)
    //{
    //    var user = _userManager.FindByIdAsync(userId);
    //    if (user is null)
    //    {
    //        throw new ArgumentException();
    //    }

    //    var wishlist = await this._context.Wishlists
    //        .Where(x => x.UserId == userId)
    //        .ToListAsync();

    //    if (wishlist is null)
    //        throw new Exception("Wishlist not found");

    //    return wishlist.Adapt<List<WishlistVM>>();
    //}

    /// <inheritdoc/>
    public async Task RemoveProductFromWishlistAsync(string userId, Guid productId, Guid wishlistId)
    {
        var user = _userManager.FindByIdAsync(userId);
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

    /// <inheritdoc/>
    public async Task RemoveWishlistAsync(Guid wishlistId, string userId)
    {
        var wishlist = await this._context.Wishlists
            .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == wishlistId);

        if (wishlist is null)
            throw new ArgumentException("Invalid wishlistId or userId");

        this._context.Remove(wishlist);
        await this._context.SaveChangesAsync();
    }
}