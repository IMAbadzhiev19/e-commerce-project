using ECommerceProject.Services.Contracts;
using ECommerceProject.Shared.Models.ECommerce;

namespace ECommerceProject.Services.Implementations;

/// <summary>
/// A class representing the email service
/// </summary>
public class EmailService : IEmailService
{
    /// <inheritdoc/>
    public Task SendProductRequestAsync(ProductRM productRM)
    {
        throw new NotImplementedException();
    }
}
