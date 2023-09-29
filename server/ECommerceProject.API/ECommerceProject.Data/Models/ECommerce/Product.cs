using ECommerceProject.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Data.Models.ECommerce;

public class Product
{
    [Key]
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public Categories Category { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = default!;
}