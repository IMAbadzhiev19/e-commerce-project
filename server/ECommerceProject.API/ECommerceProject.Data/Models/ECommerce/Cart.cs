using ECommerceProject.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Data.Models.ECommerce;

public class Cart
{
    [Key]
    public Guid Id { get; set; }

    public virtual ICollection<Product> Products { get; set; } = default!;
}