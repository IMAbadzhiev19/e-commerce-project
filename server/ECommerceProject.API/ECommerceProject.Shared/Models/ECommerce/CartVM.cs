using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Shared.Models.ECommerce;

public class CartVM
{
    public ICollection<Product> Products { get; set; } = default!;
}
