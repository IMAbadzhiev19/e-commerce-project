using ECommerceProject.Data.Data;
using ECommerceProject.Services.Contracts.ECommerce;

namespace ECommerceProject.Services.Implementations.ECommerce;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;

    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task AddProductToCart(string userId, Guid productId)
    {
        throw new NotImplementedException();
    }

    public Task CreateCart(string userId)
    {
        throw new NotImplementedException();
    }

    public Task ProceedToCheckout(string userId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveProductFromCart(string userId, Guid productId)
    {
        throw new NotImplementedException();
    }
}
