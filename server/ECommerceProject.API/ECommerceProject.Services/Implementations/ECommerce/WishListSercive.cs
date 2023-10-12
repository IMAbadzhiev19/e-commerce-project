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
    public Task AddProductToWishlist(string userId, Guid productId, Guid watchlistId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<Guid> CreateWishlist(string userId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<Wishlist> GetWishlists(string userId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task RemoveProductFromWishlist(string userId, Guid productId, Guid watchlistId)
    {
        throw new NotImplementedException();
    }
}