using ECommerceProject.Data.Models.Auth;

namespace ECommerceProject.Data.Models.ECommerce;

/// <summary>
/// Represents a watchlist in the system.
/// </summary>
public class Watchlist
{
    /// <summary>
    /// Gets or sets the unique identifier for the watchlist.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user's unique identifier who owns the watchlist.
    /// Can be null if the watchlist is not associated with any user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the watchlist, if available.
    /// Can be null if the watchlist is not associated with any user.
    /// </summary>
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets a collection of products added to the watchlist.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = default!;
}