namespace ECommerceProject.Services.Contracts.ECommerce;

public interface ICartService
{
    Task<Guid> CreateCart(string userId);

    Task AddProductToCart(string userId, Guid productId, Guid cartId);

    Task RemoveProductFromCart(string userId, Guid productId, Guid cartId);

    Task ProceedToCheckout(string userId);
}