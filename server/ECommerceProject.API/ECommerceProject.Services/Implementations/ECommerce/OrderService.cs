using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.Services.Implementations.ECommerce;

/// <summary>
/// A class representing the order service
/// </summary>
public class OrderService: IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="user"></param>
    public OrderService(ApplicationDbContext context, UserManager<ApplicationUser> user)
    {
        this._context = context;
        this._userManager = user;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateOrderAsync(string userId, OrderIM order)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new ArgumentException("This user doesn't exist"); 
        }

        var cart = await this._context.Carts.FindAsync(order.CartId);
        if(cart is null)
        {
            throw new ArgumentException("This cart doesn't exist");
        }
        cart.IsActive = false;
        var newOrder = order.Adapt<Order>();

        this._context.Carts.Update(cart);
        await this._context.Orders.AddAsync(newOrder);
        await this._context.SaveChangesAsync();
        
        return newOrder.Id;
    }

    /// <inheritdoc/>
    public async Task<OrderVM> GetOrderByIdAsync(string userId, Guid orderId)
    {
        var order = await this._context.Orders.FindAsync(orderId);

        if (order is null)
            throw new ArgumentException("Invalid orderId");

        if (order.UserId != userId)
            throw new Exception("This order doesn't belong to this user");

        return order.Adapt<OrderVM>();
    }

    /// <inheritdoc/>
    public async Task<ICollection<OrderVM>> GetOrdersAsync(string userId)
    {
        var orders = await _context.Orders.Where(o => o.UserId == userId).ToListAsync();

        if(orders is null)
        {
            throw new ArgumentException("This user doesn't have orders");
        }

        return orders.Adapt<List<OrderVM>>();
    }

    /// <inheritdoc/>
    public async Task RemoveOrderAsync(string userId, Guid orderId)
    {
        var order = _context.Orders.FirstOrDefaultAsync(o=>o.UserId == userId && o.Id == orderId);

        if(order is null)
        {
            throw new ArgumentException("This order isn't your or doesn't exist");
        }

        this._context.Remove(order);
        await _context.SaveChangesAsync();
    }
}