using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Shared.Models.ECommerce;

public class CartVM
{
    public Guid Id { get; set; }

    public ApplicationUser? User { get; set; }

    public ICollection<Product> Products { get; set; } = default!;
}
