namespace ECommerceProject.Shared.Models.ECommerce;

/// <summary>
/// Comment Input Model
/// </summary>
public class CommentIM
{
    /// <summary>
    /// The content of the comment
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// The Id of the product associated with the comment
    /// </summary>
    public Guid ProductId { get; set; }
}