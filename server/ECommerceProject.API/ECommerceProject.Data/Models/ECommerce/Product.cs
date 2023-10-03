using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Data.Models.ECommerce;

public class Product
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public int? Quantity { get; set; }

    public List<(float size, int quantity)>? AvailableShoeSizes { get; set; } = default!;

    public Categories Category { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = default!;
}