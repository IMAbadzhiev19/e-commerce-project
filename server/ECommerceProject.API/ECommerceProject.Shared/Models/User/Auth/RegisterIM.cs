using ECommerceProject.Data.Models.Auth;
using Mapster;

namespace ECommerceProject.Shared.Models.User.Auth;

/// <summary>
/// Register Input Model
/// </summary>
public class RegisterIM
{
    /// <summary>
    /// The username of the user
    /// </summary>
    //[StringLength(19, MinimumLength = 5, ErrorMessage = "Username must be between {1} and {2}")]
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// The first name of the user
    /// </summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>
    /// The last name of the user
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// The email of the user
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The address of the user
    /// </summary>
    public Address Address { get; set; } = default!;

    /// <summary>
    /// The phone number of the user
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// The password of the user (not hashed)
    /// </summary>
    [AdaptIgnore]
    public string PasswordHash { get; set; } = string.Empty;
}