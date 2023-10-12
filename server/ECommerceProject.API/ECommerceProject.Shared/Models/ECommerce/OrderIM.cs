using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Shared.Models.ECommerce;

/// <summary>
/// Represents the input model for creating an order.
/// </summary>
public class OrderIM
{
    /// <summary>
    /// Gets or sets the status of the order.
    /// </summary>
    public Status Status { get; set; }

    /// <summary>
    /// Gets or sets the date when the order was created.
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// Gets or sets the expected delivery date of the order.
    /// </summary>
    public DateTime DeliveryDate { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the shopping cart associated with the order.
    /// </summary>
    public Guid CartId { get; set; }
}