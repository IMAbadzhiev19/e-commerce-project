namespace ECommerceProject.Shared.Models.ECommerce;

public class CommentIM
{
    public string Text { get; set; } = string.Empty;

    public Guid ProductId { get; set; }
}