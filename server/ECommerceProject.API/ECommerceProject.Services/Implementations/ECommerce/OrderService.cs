using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.Services.Implementations.ECommerce
{
    public class OrderService: IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public OrderService(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            this._context = context;
            this._user = user;
        }

        public Task<Guid> CreateOrder(string userId, Guid cartId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrders(string userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveOrder(string userid, Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}
