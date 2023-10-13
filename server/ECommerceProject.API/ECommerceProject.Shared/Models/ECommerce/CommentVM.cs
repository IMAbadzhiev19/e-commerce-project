using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.ECommerce;

namespace ECommerceProject.Shared.Models.ECommerce;

public class CommentVM
{
    /// <summary>
    /// Gets or sets the unique identifier for the comment.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the comment, if available.
    /// Can be null if the user is anonymous.
    /// </summary>
    public ApplicationUser? User { get; set; }

    /// <summary>
    /// Gets or sets the text content of the comment.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Gets or sets the product related to the comment, if available.
    /// Can be null if not associated with any product.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the comment was posted.
    /// </summary>
    public DateTime Date { get; set; }
}
