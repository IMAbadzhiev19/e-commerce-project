using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Data.Models.Auth;

public class Address
{
    public int? Number { get; set; }

    public string Street { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;
}
