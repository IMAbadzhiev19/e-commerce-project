namespace ECommerceProject.Shared.Models.User.Auth;

/// <summary>
/// Login Input Model
/// </summary>
public class LoginIM
{
    /// <summary>
    /// The email of the user
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The password of the user
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
