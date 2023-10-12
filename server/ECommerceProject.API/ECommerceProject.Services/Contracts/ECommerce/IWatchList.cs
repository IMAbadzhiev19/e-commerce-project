using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Interface representing a service for managing watchlists.
/// </summary>
public interface IWatchList
{
    /// <summary>
    /// Create a new wishlist for a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user creating the watchlist.</param>
    /// <returns>The unique identifier of the created watchlist.</returns>
    Task<Guid> CreateWatchList(string userId);

    /// <summary>
    /// Add a product to a user's watchlist.
    /// </summary>
    /// <param name="userId">The unique identifier of the user adding the product.</param>
    /// <param name="productId">The unique identifier of the product to add.</param>
    /// <param name="watchlistId">The unique identifier of the watchlist to add the product to.</param>
    Task AddProductToWatchlist(string userId, Guid productId, Guid watchlistId);

    /// <summary>
    /// Remove a product from a user's watchlist.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the product.</param>
    /// <param name="productId">The unique identifier of the product to remove.</param>
    /// <param name="watchlistId">The unique identifier of the watchlist to remove the product from.</param>
    Task RemoveProductFromWatchlist(string userId, Guid productId, Guid watchlistId);

    /// <summary>
    /// Get a user's watchlists.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve watchlist for.</param>
    /// <returns>Task representing the user's watchlist.</returns>
    Task<Watchlist> GetWatchlists(string userId);
}