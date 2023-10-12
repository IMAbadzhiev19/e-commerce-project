using ECommerceProject.Data.Models.Auth;

namespace ECommerceProject.Data.Models.ECommerce;

/// <summary>
/// Represents a review in the system.
/// </summary>
public class Review
{
    /// <summary>
    /// Gets or sets the unique identifier for the review.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user's unique identifier who posted the review.
    /// Can be null if the review is anonymous.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the review, if available.
    /// Can be null if the review is anonymous.
    /// </summary>
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the product related to the review.
    /// Can be null if not associated with any product.
    /// </summary>
    public Guid? ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product related to the review, if available.
    /// Can be null if not associated with any product.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Gets or sets the grade or rating for the review.
    /// Can be null if a rating is not provided.
    /// </summary>
    public int? Grade { get; set; }
}