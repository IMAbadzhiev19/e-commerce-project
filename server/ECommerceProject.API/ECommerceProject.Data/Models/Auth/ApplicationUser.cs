using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ECommerceProject.Data.Models.ECommerce;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Data.Models.Auth;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;

    public Address Address { get; set; } = default!;

    public Guid? CartId { get; set; }
    
    public virtual Cart? Cart { get; set; }
}