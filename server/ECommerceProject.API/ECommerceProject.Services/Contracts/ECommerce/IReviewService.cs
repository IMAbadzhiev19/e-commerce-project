﻿using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;

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
    /// <param name="review">The input model of the review entity.</param>
    /// <returns>The unique identifier of the created review.</returns>
    Task<Guid> CreateReviewAsync(string userId, ReviewIM review);

    /// <summary>
    /// Remove an existing review.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the review.</param>
    /// <param name="reviewId">The unique identifier of the review to remove.</param>
    /// <returns>Task representing the removal operation.</returns>
    Task RemoveReviewAsync(string userId, Guid reviewId);

    /// <summary>
    /// Get a collection of reviews associated with a user.
    /// </summary>
    /// <param name="productId">The unique identifier of the user to retrieve reviews for.</param>
    /// <returns>Task representing a collection of reviews.</returns>
    Task<ICollection<ReviewVM>> GetReviewsAsync(Guid productId);

    /// <summary>
    /// Get a review by its unique identitifer associated with user
    /// </summary>
    /// <param name="userId">The unique identifier of the user</param>
    /// <param name="reviewId">The unique identitifer of the review</param>
    /// <returns></returns>
    Task<ReviewVM> GetReviewByIdAsync(string userId, Guid reviewId);
}
