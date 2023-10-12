using Microsoft.AspNetCore.Http;

namespace ECommerceProject.Services.Contracts;

/// <summary>
/// Interface representing a service for uploading image files.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Asynchronously upload an image file for a product.
    /// </summary>
    /// <param name="image">The image file to upload.</param>
    /// <param name="productId">The unique identifier of the product associated with the image.</param>
    Task UploadImageAsync(IFormFile image, Guid productId);
}