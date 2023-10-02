namespace ECommerceProject.Services.Contracts.ECommerce;

public interface ICartService
{
    Task CreateCart(string userId);

    Task AddProductToCart(string userId, Guid productId);

    Task RemoveProductFromCart(string userId, Guid productId);

    Task ProceedToCheckout(string userId);
}