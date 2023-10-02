using ECommerceProject.Data.Models.Enums;
using Mapster;

namespace ECommerceProject.Shared.Models.ECommerce;

public class ProductVM
{
    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int Quantity { get; set; }
    
    public string Category { get; set; } = string.Empty;
}