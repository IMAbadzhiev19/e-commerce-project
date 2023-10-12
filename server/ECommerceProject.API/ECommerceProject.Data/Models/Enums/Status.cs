namespace ECommerceProject.Data.Models.Enums;

/// <summary>
/// Represents order statuses.
/// </summary>
public enum Status
{
    /// <summary>
    /// The order is currently being packed.
    /// </summary>
    Packing,

    /// <summary>
    /// The order is in transit and traveling to its destination.
    /// </summary>
    Travelling,

    /// <summary>
    /// The order has been delivered to the customer.
    /// </summary>
    Delivered,
}