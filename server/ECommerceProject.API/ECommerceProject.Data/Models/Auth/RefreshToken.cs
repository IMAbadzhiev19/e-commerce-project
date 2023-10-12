using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceProject.Data.Models.Auth;

/// <summary>
/// Represents a refresh token used for token-based authentication.
/// </summary>
public class RefreshToken
{
    /// <summary>
    /// Gets or sets the unique identifier of the refresh token.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the refresh token itself.
    /// </summary>
    public string? Token { get; set; }

    /// <summary>
    /// Gets or sets the foreign key representing the unique identifier of the user associated with this refresh token.
    /// Can be null if the refresh token is not associated with any user.
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the refresh token, if available.
    /// Can be null if the refresh token is not associated with any user.
    /// </summary>
    [ForeignKey(nameof(UserId))]
    public ApplicationUser? User { get; set; }
}