using Microsoft.AspNetCore.Http;

namespace ECommerceProject.Shared.Models.ECommerce;

public class ProductRM
{
    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public string Category { get; set; } = string.Empty;

    public string? Comments { get; set; }
}