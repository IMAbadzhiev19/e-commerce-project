using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

public interface IReviewService
{
    Task<Guid> CreateReview(string userId, Guid productId);

    Task RemoveReview(string userId,Guid reviewId);

    Task<ICollection<Review>> GetReviews(string userId);
}
