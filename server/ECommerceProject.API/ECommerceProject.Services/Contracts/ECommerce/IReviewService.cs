﻿using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Interface representing a service for managing product reviews.
/// </summary>
public interface IReviewService
{
    /// <summary>
    /// Create a new review for a product.
    /// </summary>
    /// <param name="userId">The unique identifier of the user creating the review.</param>
    /// <param name="productId">The unique identifier of the product to review.</param>
    /// <returns>The unique identifier of the created review.</returns>
    Task<Guid> CreateReview(string userId, Guid productId);

    /// <summary>
    /// Remove an existing review.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the review.</param>
    /// <param name="reviewId">The unique identifier of the review to remove.</param>
    /// <returns>Task representing the removal operation.</returns>
    Task RemoveReview(string userId, Guid reviewId);

    /// <summary>
    /// Get a collection of reviews associated with a user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user to retrieve reviews for.</param>
    /// <returns>Task representing a collection of reviews.</returns>
    Task<ICollection<Review>> GetReviews(string userId);
}
