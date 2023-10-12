using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Interface representing a service for managing watchlists.
/// </summary>
public interface IWishlistService
{
    /// <summary>
    /// Create a new wishlist for a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user creating the watchlist.</param>
    /// <returns>The unique identifier of the created watchlist.</returns>
    Task<Guid> CreateWishlist(string userId);

    /// <summary>
    /// Add a product to a user's watchlist.
    /// </summary>
    /// <param name="userId">The unique identifier of the user adding the product.</param>
    /// <param name="productId">The unique identifier of the product to add.</param>
    /// <param name="wishListId">The unique identifier of the watchlist to add the product to.</param>
    Task AddProductToWishlist(string userId, Guid productId, Guid wishListId);

    /// <summary>
    /// Remove a product from a user's watchlist.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the product.</param>
    /// <param name="productId">The unique identifier of the product to remove.</param>
    /// <param name="wishListId">The unique identifier of the watchlist to remove the product from.</param>
    Task RemoveProductFromWishlist(string userId, Guid productId, Guid wishListId);

    /// <summary>
    /// Get a user's watchlists.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve watchlist for.</param>
    /// <returns>Task representing the user's watchlist.</returns>
    Task<Wishlist> GetWishlists(string userId);
}