namespace ECommerceProject.Shared.Models.ECommerce;

/// <summary>
/// Product Update Model
/// </summary>
public class ProductIM
{
    /// <summary>
    /// A class constructor inizializing the quanity with a random value (can be overwritten anytime)
    /// </summary>
    public ProductIM()
    {
        var rnd = new Random();
        this.Quantity = rnd.Next(1, 1001);
    }
    
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