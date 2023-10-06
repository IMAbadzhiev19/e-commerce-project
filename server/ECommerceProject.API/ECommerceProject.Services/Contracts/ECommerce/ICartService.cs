namespace ECommerceProject.Services.Contracts.ECommerce;

public interface ICartService
{
    Task<Guid> CreateCart(string userId);

    Task AddProductToCart(Guid productId, Guid cartId);

    Task RemoveProductFromCart(Guid productId, Guid cartId);
}