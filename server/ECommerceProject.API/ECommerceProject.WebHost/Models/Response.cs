namespace ECommerceProject.WebHost.Models;

/// <summary>
/// The model used for api responses
/// </summary>
public class Response
{
    /// <summary>
    /// The status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// The message
    /// </summary>
    public string? Message { get; set; } = string.Empty;
}
