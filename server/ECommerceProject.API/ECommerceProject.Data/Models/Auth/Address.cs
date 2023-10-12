namespace ECommerceProject.Data.Models.Auth;

/// <summary>
/// Represents an address in the system.
/// </summary>
public class Address
{
    /// <summary>
    /// Gets or sets the address number. Can be null.
    /// </summary>
    public int? Number { get; set; }

    /// <summary>
    /// Gets or sets the street of the address.
    /// </summary>
    public string Street { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the city where the address is located.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the region where the city is situated and where the address is located.
    /// </summary>
    public string Region { get; set; } = string.Empty;
}