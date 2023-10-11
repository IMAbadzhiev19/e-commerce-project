namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Cart Service Interface
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Asynchronous method used for creating a cart and assigning it to an user
    /// </summary>
    /// <param name="userId">The id of the user</param>
    /// <returns>The id of the cart</returns>
    Task<Guid> CreateCart(string userId);

    /// <summary>
    /// Asynchronous method used for adding a product to a cart
    /// </summary>
    /// <param name="productId">The id of the product</param>
    /// <param name="cartId">The id of the cart</param>
    /// <returns></returns>
    Task AddProductToCart(Guid productId, Guid cartId);

    /// <summary>
    /// Asynchronous method used for removing a product from the cart
    /// </summary>
    /// <param name="productId">The id of the product</param>
    /// <param name="cartId">The id of the cart</param>
    /// <returns></returns>
    Task RemoveProductFromCart(Guid productId, Guid cartId);
}