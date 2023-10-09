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
    public class WishlistService: IWishlistService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public WishlistService(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            this._context = context;
            this._user = user;
        }

        public Task AddProductToWashlist(string userId, Guid productId, Guid washlistId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> CreateWashlist(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Wishlist> GetWishlists(string userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProductFromWashlist(string userId, Guid productId, Guid washlistId)
        {
            throw new NotImplementedException();
        }
    }
}
