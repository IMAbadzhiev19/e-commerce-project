using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Shared.Models.ECommerce;

public class WishlistVM
{
    /// <summary>
    /// Gets or sets the unique identifier for the wishlist.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the wishlist, if available.
    /// Can be null if the wishlist is not associated with any user.
    /// </summary>
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets a collection of products added to the wishlist.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = default!;
}
