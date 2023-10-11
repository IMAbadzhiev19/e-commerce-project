namespace ECommerceProject.WebHost.Models.User;

/// <summary>
/// Change Password Model
/// </summary>
public class ChangePasswordModel
{
    /// <summary>
    /// The old password
    /// </summary>
    public string OldPassword { get; set; } = string.Empty;

    /// <summary>
    /// The new password
    /// </summary>
    public string NewPassword { get; set; } = string.Empty;
}
