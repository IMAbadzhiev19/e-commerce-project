using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Data.Models.ECommerce;

/// <summary>
/// Represents a product in the system.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL of the image associated with the product.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product available in stock.
    /// Can be null if the quantity is not specified.
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the category to which the product belongs.
    /// </summary>
    public Categories Category { get; set; }

    /// <summary>
    /// Gets a collection of carts containing this product.
    /// </summary>
    public virtual ICollection<Cart> Carts { get; set; } = default!;

    public virtual ICollection<Comment> Comments { get; set; } = default!;

    public virtual ICollection<Review> Reviews { get; set; } = default!;
}