using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;

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
    Task<Guid> CreateWishlistAsync(string userId);

    /// <summary>
    /// Add a product to a user's watchlist.
    /// </summary>
    /// <param name="userId">The unique identifier of the user adding the product.</param>
    /// <param name="productId">The unique identifier of the product to add.</param>
    /// <param name="wishListId">The unique identifier of the watchlist to add the product to.</param>
    Task AddProductToWishlistAsync(string userId, Guid productId, Guid wishListId);

    /// <summary>
    /// Remove a product from a user's watchlist.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the product.</param>
    /// <param name="productId">The unique identifier of the product to remove.</param>
    /// <param name="wishListId">The unique identifier of the watchlist to remove the product from.</param>
    Task RemoveProductFromWishlistAsync(string userId, Guid productId, Guid wishListId);

    /// <summary>
    /// Get a user's watchlists.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve watchlist for.</param>
    /// <returns>Task representing the user's watchlist.</returns>
   // Task<ICollection<WishlistVM>> GetWishlistsAsync(string userId);

    /// <summary>
    /// Removes user's wishlist
    /// </summary>
    /// <param name="wishlistId">The unique identifier of the wishlist</param>
    /// <param name="userId">The unique identifier of the user</param>
    Task RemoveWishlistAsync(Guid wishlistId, string userId);

    /// <summary>
    /// Gets a wishlist associated with a user by its unique identifier
    /// </summary>
    /// <param name="userId">The unique identitifer of the user</param>
    /// <param name="wishlistId">The unique identitifer of the wishlist</param>
    /// <returns>Wishlist View Model</returns>
    Task<WishlistVM> GetWishlistByIdAsync(string userId);
}