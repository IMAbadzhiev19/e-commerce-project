using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Data.Models.Auth;

public class RefreshToken
{
    public Guid Id { get; set; }

    public string? Token { get; set; }

    public string? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}
