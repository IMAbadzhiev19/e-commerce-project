using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Interface representing a service for managing orders.
/// </summary>
public interface IOrderService
{
    /// <summary>
    /// Create a new order based on the contents of a user's cart.
    /// </summary>
    /// <param name="userId">The unique identifier of the user creating the order.</param>
    /// <param name="cartId">The unique identifier of the cart to use for creating the order.</param>
    /// <returns>The unique identifier of the created order.</returns>
    Task<Guid> CreateOrder(string userId, Guid cartId);

    /// <summary>
    /// Remove an existing order.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the order.</param>
    /// <param name="orderId">The unique identifier of the order to remove.</param>
    /// <returns>Task representing the removal operation.</returns>
    Task RemoveOrder(string userId, Guid orderId);

    /// <summary>
    /// Get a collection of orders associated with a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve orders for.</param>
    /// <returns>Task representing a collection of orders.</returns>
    Task<ICollection<Order>> GetOrders(string userId);
}