using ECommerceProject.Data.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Data.Models.ECommerce;

public class Cart
{
    [Key]
    public Guid Id { get; set; }

    public string UserId { get; set; } = string.Empty;

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }

    public virtual ICollection<Product> Products { get; set; } = default!;
}