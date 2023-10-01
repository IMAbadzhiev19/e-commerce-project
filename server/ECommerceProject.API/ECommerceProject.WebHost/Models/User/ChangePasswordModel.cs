namespace ECommerceProject.WebHost.Models.User;

public class ChangePasswordModel
{
    public string OldPassword { get; set; } = string.Empty;

    public string NewPassword { get; set; } = string.Empty;
}
