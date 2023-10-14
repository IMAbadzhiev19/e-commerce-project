using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;

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
    /// <param name="">The unique identifier of the cart to use for creating the order.</param>
    /// <returns>The unique identifier of the created order.</returns>
    Task<Guid> CreateOrderAsync(string userId, OrderIM order);

    /// <summary>
    /// Remove an existing order.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the order.</param>
    /// <param name="orderId">The unique identifier of the order to remove.</param>
    /// <returns>Task representing the removal operation.</returns>
    Task RemoveOrderAsync(string userId, Guid orderId);

    /// <summary>
    /// Get a collection of orders associated with a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve orders for.</param>
    /// <returns>Task representing a collection of orders.</returns>
    Task<ICollection<OrderVM>> GetOrdersAsync(string userId);

    /// <summary>
    /// Get a order associated with a user
    /// </summary>
    /// <param name="userId">The unique identitifer of the user</param>
    /// <param name="orderId">The unique identitifer of the order</param>
    /// <returns>Order View Model</returns>
    Task<OrderVM> GetOrderByIdAsync(string userId, Guid orderId);
}