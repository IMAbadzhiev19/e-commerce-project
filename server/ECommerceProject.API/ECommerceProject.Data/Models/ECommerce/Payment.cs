using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.Enums;

namespace ECommerceProject.Data.Models.ECommerce;

/// <summary>
/// Represents a payment made in the system.
/// </summary>
public class Payment
{
    /// <summary>
    /// Gets or sets the unique identifier for the payment.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user's unique identifier who made the payment.
    /// Can be null if the payment is made by an anonymous user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the payment, if available.
    /// Can be null if the payment is made by an anonymous user.
    /// </summary>
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the order associated with this payment.
    /// Can be null if there is no associated order.
    /// </summary>
    public Guid? OrderId { get; set; }

    /// <summary>
    /// Gets or sets the order associated with this payment, if available.
    /// Can be null if there is no associated order.
    /// </summary>
    public Order? Order { get; set; }

    /// <summary>
    /// Gets or sets the price of the payment.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the type of payment (e.g., credit card, cash, etc.).
    /// </summary>
    public PaymentType Type { get; set; } = default!;
}