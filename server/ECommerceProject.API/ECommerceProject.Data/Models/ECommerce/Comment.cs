using ECommerceProject.Data.Models.Auth;

namespace ECommerceProject.Data.Models.ECommerce;

public class Comment
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public ApplicationUser? User { get; set; }

    public string? Text { get; set; }

    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }

    public DateTime Date { get; set; }
}
