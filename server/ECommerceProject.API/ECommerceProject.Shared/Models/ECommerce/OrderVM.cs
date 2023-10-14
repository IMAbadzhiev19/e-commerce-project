using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Shared.Models.ECommerce;

/// <summary>
/// A class representing the order view model
/// </summary>
public class OrderVM
{
    /// <summary>
    /// Gets or sets the unique identifier for the order.
    /// </summary>
    public Guid Id { get; set; }

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
    /// Gets or sets the cart associated with this order, if available.
    /// Can be null if there is no associated cart.
    /// </summary>
    public Cart? Cart { get; set; }
}
