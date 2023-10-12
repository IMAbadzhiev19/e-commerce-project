namespace ECommerceProject.Services.Contracts.User;

/// <summary>
/// Interface representing the current user, providing the user's unique identifier.
/// </summary>
public interface ICurrentUser
{
    /// <summary>
    /// Gets the unique identifier of the current user.
    /// </summary>
    string UserId { get; }
}
