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
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public ReviewService(ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            this._context = context;
            this._user = user;
        }

        public Task<Guid> CreateReview(string userId, Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Review>> GetReviews(string userId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveReview(string userId, Guid reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
