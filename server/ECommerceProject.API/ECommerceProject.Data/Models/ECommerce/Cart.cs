using ECommerceProject.Data.Models.Auth;

namespace ECommerceProject.Data.Models.ECommerce;

/// <summary>
/// A class representing a cart model.
/// </summary>
public class Cart
{
    /// <summary>
    /// Gets or sets the unique identifier of the cart.
    /// </summary>
    public Guid Id { get; set; }

    public bool IsActive { get; set; } = true;
    /// <summary>
    /// Gets or sets the foreign key representing the identifier of the user related to this cart.
    /// Can be null if the cart is not associated with any user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the navigation property related to the UserId foreign key.
    /// Can be null if the cart is not associated with any user.
    /// </summary>
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets or sets a collection containing all the products in the cart.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = default!;
}