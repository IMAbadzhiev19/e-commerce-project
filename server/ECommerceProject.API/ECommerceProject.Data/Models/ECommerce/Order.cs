using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Data.Models.ECommerce;

public class Order
{
    public Guid Id{ get; set; }

    public string? UserId { get; set; }

    public ApplicationUser? User { get; set; }

    public Status Status { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime DeliveryDate { get; set; }

    public Guid? CartId { get; set;}

    public Cart? Cart { get; set; }
}
