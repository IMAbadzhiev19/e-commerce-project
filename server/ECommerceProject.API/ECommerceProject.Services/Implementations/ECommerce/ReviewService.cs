using ECommerceProject.Data.Data;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
    public async Task<Guid> CreateReview(string userId, ReviewIM review)
    {
        var product = await this._context.Products.FindAsync(review.ProductId);
        if (product == null)
        {
            throw new ArgumentException();
        }

        var user = _user.FindByIdAsync(userId);
        if (user == null)
        {
            throw new ArgumentException();
        }

        Review newReview = new Review()
        { 
            Grade = review.Grade,
            UserId = userId,
            ProductId = review.ProductId,
        };

        this._context.Reviews.Add(newReview);
        await _context.SaveChangesAsync();
        return newReview.Id;
    }

    /// <inheritdoc/>
    public async Task<ICollection<Review>> GetReviews(Guid productId)
    {
        var product = await this._context.Products.FindAsync(productId);
        if(product == null)
        {
            throw new ArgumentException();
        }

        var reviews = await _context.Reviews.Where(r=>r.ProductId == productId).ToListAsync();
        if(reviews == null)
        {
            throw new ArgumentException();
        }

        return reviews;
    }

    /// <inheritdoc/>
    public async Task RemoveReview(string userId, Guid reviewId)
    {
        
    }
}
