namespace ECommerceProject.Shared.Models.ECommerce;

/// <summary>
/// Product Update Model
/// </summary>
public class ProductUM
{
    /// <summary>
    /// The title of the product
    /// </summary>
    public string? Title { get; set; } = string.Empty;

    /// <summary>
    /// The price of the product
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// The description of the product
    /// </summary>
    public string? Description { get; set; } = string.Empty;

    /// <summary>
    /// The URL of the product's image
    /// </summary>
    public string? ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product
    /// </summary>
    public int? Quantity { get; set; }
}