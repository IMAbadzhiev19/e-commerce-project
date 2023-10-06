namespace ECommerceProject.Data.Models.ECommerce;

public class Payment
{
    public Guid Id { get; set; }

    public Guid? OrderId { get; set; }

    public Order? Order { get; set; }

    public decimal Price { get; set; }

    public Type Type { get; set; } = default!;
}
