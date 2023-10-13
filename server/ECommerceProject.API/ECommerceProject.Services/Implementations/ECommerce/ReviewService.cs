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
/// A class representing the review service.
/// </summary>
public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    /// <summary>
    /// A constructor used for injecting dependencies
    /// </summary>
    /// <param name="context"></param>
    /// <param name="user"></param>
    public ReviewService(ApplicationDbContext context, UserManager<ApplicationUser> user)
    {
        this._context = context;
        this._userManager = user;
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateReviewAsync(string userId, ReviewIM reviewIM)
    {
        var product = await this._context.Products.FindAsync(reviewIM.ProductId);
        if (product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        var user = _userManager.FindByIdAsync(userId);
        if (user is null)
        {
            throw new ArgumentException("Invalid userId");
        }

        var review = reviewIM.Adapt<Review>();
        review.UserId = userId;

        await this._context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        return review.Id;
    }

    /// <inheritdoc/>
    public async Task<ICollection<Review>> GetReviewsAsync(Guid productId)
    {
        var product = await this._context.Products.FindAsync(productId);
        if(product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        var reviews = await _context.Reviews
            .Where(r=>r.ProductId == productId)
            .ToListAsync();
        
        if(reviews is null)
        {
            throw new Exception("Review not found");
        }

        return reviews;
    }

    /// <inheritdoc/>
    public async Task RemoveReviewAsync(string userId, Guid reviewId)
    {
        throw new NotImplementedException();
    }
}
