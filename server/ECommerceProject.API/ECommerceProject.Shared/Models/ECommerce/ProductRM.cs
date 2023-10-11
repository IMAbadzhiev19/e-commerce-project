namespace ECommerceProject.Shared.Models.ECommerce;

/// <summary>
/// Product Request Model
/// </summary>
public class ProductRM
{
    /// <summary>
    /// The title of the product
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The price of the product
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// The description of the product
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The category of the product
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Comments -> (Any additional recommendations for the requested product)
    /// </summary>
    public string? Comments { get; set; }
}