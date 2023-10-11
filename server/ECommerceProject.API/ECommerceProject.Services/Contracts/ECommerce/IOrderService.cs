using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

public interface IOrderService
{
    Task<Guid> CreateOrder(string userId, Guid cartId);

    Task RemoveOrder(string userid, Guid orderId);

    Task<ICollection<Order>> GetOrders(string userId);
}
