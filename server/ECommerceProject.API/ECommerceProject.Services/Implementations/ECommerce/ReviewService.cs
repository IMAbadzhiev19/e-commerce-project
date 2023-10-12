using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Services.Implementations.ECommerce;

/// <summary>
/// A class representing the review service.
/// </summary>
public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _user;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="user"></param>
    public ReviewService(ApplicationDbContext context, UserManager<ApplicationUser> user)
    {
        this._context = context;
        this._user = user;
    }

    /// <inheritdoc/>
    public Task<Guid> CreateReview(string userId, Guid productId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<ICollection<Review>> GetReviews(string userId)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task RemoveReview(string userId, Guid reviewId)
    {
        throw new NotImplementedException();
    }
}
