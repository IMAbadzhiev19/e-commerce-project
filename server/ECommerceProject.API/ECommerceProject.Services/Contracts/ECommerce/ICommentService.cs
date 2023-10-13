using ECommerceProject.Data.Models.ECommerce;
using ECommerceProject.Shared.Models.ECommerce;

namespace ECommerceProject.Services.Contracts.ECommerce;

/// <summary>
/// Interface representing a service for managing comments.
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Create a new comment for a product.
    /// </summary>
    /// <param name="userId">The unique identifier of the user creating the comment.</param>
    /// <param name="commentIM">The input model for the new comment.</param>
    /// <returns>The unique identifier of the created comment.</returns>
    Task<Guid> CreateCommentAsync(string userId, CommentIM commentIM);

    /// <summary>
    /// Remove a comment.
    /// </summary>
    /// <param name="userId">The unique identifier of the user removing the comment.</param>
    /// <param name="commentId">The unique identifier of the comment to remove.</param>
    /// <returns>Task representing the removal operation.</returns>
    Task RemoveCommentAsync(string userId, Guid commentId);

    /// <summary>
    /// Get a collection of comments associated with a product.
    /// </summary>
    /// <param name="productId">The unique identifier of the product to retrieve comments for.</param>
    /// <returns>Task representing a collection of comments.</returns>
    Task<ICollection<CommentVM>> GetCommentsAsync(Guid productId);
}