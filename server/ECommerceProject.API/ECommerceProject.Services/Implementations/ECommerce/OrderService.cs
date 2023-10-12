﻿using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.ECommerce;

/// <summary>
/// A class representing the order service
/// </summary>
public class OrderService: IOrderService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _user;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="user"></param>
    public OrderService(ApplicationDbContext context, UserManager<ApplicationUser> user)
    {
        this._context = context;
        this._user = user;
    }

    /// <inheritdoc/>
    public Task<Guid> CreateOrder(string userId, Guid cartId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<ICollection<Order>> GetOrders(string userId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task RemoveOrder(string userid, Guid orderId)
    {
        throw new NotImplementedException();
    }
}