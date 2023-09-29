using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceProject.Data.Models.ECommerce;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Data.Models.Auth;

public class User : IdentityUser
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    public string LastName { get; set; } = string.Empty;


    public Guid? CartId { get; set; }
    
    [ForeignKey(nameof(CartId))]
    public virtual Cart? Cart { get; set; }
}