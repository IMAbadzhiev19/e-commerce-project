using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

public interface IWishlistService
{
    Task<Guid> CreateWashlist(string userId);

    Task AddProductToWashlist(string userId, Guid productId, Guid washlistId);

    Task RemoveProductFromWashlist(string userId, Guid productId,Guid washlistId);

    Task<Wishlist> GetWishlists(string userId);
}
