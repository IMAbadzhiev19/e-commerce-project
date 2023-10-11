namespace ECommerceProject.Shared.Models.User;

/// <summary>
/// User View Model
/// </summary>
public class UserVM
{
    /// <summary>
    /// The username of the user
    /// </summary>
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
    /// The phone number of the user
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;
}
