using Mapster;
using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Services.Models;

public class RegisterIM
{
    //[StringLength(19, MinimumLength = 5, ErrorMessage = "Username must be between {1} and {2}")]
    public string UserName { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    [AdaptIgnore]
    public string PasswordHash { get; set; } = string.Empty;
}