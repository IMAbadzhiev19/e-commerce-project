using Microsoft.AspNetCore.Http;

namespace ECommerceProject.Services.Contracts;

public interface IFileService
{
    Task UploadImageAsync(IFormFile image, Guid productId);
}