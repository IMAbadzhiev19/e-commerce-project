using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Data.Models.ECommerce;

/// <summary>
/// Represents an order in the system.
/// </summary>
public class Order
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user's unique identifier who placed the order.
    /// Can be null if the order is anonymous.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the order, if available.
    /// Can be null if the order is anonymous.
    /// </summary>
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets or sets the status of the order.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the order was placed.
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Gets or sets the expected delivery date for the order.
    /// </summary>
    public DateTime DeliveryDate { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the cart associated with this order.
    /// Can be null if there is no associated cart.
    /// </summary>
    public Guid? CartId { get; set; }

    /// <summary>
    /// Gets or sets the cart associated with this order, if available.
    /// Can be null if there is no associated cart.
    /// </summary>
    public Cart? Cart { get; set; }
}