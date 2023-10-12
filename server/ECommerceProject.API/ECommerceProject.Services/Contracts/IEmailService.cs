using ECommerceProject.Shared.Models.ECommerce;

namespace ECommerceProject.Services.Contracts;

/// <summary>
/// Interface representing a service for sending email notifications related to product requests.
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Asynchronously send an email notification for a product request.
    /// </summary>
    /// <param name="productRM">The product request model containing the required information for the email.</param>
    Task SendProductRequest(ProductRM productRM);
}