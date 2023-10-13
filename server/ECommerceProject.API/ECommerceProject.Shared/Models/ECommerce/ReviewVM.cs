using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Shared.Models.ECommerce;

public class ReviewVM
{
    /// <summary>
    /// Gets or sets the user associated with the review, if available.
    /// Can be null if the review is anonymous.
    /// </summary>
    public ApplicationUser? User { get; set; }

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
