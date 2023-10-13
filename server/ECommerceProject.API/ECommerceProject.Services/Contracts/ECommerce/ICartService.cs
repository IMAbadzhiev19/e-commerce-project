namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Cart Service Interface
/// </summary>
public interface ICartService
{
    /// <summary>
    /// Asynchronous method used for creating a cart and assigning it to a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>The unique identifier of the created cart.</returns>
    Task<Guid> CreateCartAsync(string userId);

    /// <summary>
    /// Asynchronous method used for adding a product to a cart.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to add to the cart.</param>
    /// <param name="cartId">The unique identifier of the cart to add the product to.</param>
    /// <returns>Task representing the add operation.</returns>
    Task AddProductToCartAsync(Guid productId, Guid cartId);

    /// <summary>
    /// Asynchronous method used for removing a product from a cart.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to remove from the cart.</param>
    /// <param name="cartId">The unique identifier of the cart to remove the product from.</param>
    /// <returns>Task representing the removal operation.</returns>
    Task RemoveProductFromCartAsync(Guid productId, Guid cartId);
}