using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Shared.Models.ECommerce;

public class ProductUM
{
    public string? Title { get; set; } = string.Empty;

    public decimal? Price { get; set; }

    public string? Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; } = string.Empty;

    public int? Quantity { get; set; }
}