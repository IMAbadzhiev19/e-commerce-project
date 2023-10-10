using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Data.Models.ECommerce;

public class Payment
{
    public Guid Id { get; set; }

    public string? UserId { get; set; }

    public ApplicationUser? User { get; set; }

    public Guid? OrderId { get; set; }

    public Order? Order { get; set; }

    public decimal Price { get; set; }

    public PaymentType Type { get; set; } = default!;
}
