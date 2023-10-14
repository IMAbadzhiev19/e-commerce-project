namespace ECommerceProject.Data.Models.Auth;

/// <summary>
/// A class representing the available roles of the user
/// </summary>
public static class UserRoles
{
    /// <summary>
    /// The main role and the most basic one
    /// </summary>
    public const string User = "User";

    /// <summary>
    /// Administrator role which gives you access to some features a user doesn't have access to
    /// </summary>
    public const string Admin = "Admin";
}