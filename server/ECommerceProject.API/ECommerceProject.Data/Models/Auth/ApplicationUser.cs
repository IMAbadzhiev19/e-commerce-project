using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Data.Models.Auth;

/// <summary>
/// Represents an application user, extending the IdentityUser class.
/// </summary>
public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the user.
    /// </summary>
    public Address Address { get; set; } = default!;
}