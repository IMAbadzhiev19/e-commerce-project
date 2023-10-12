using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using ECommerceProject.Data.Data;
using ECommerceProject.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace ECommerceProject.Services.Implementations;

/// <summary>
/// A class representing the file service.
/// </summary>
public class FileService : IFileService
{
    private readonly IConfiguration _config;
    private readonly BlobServiceClient _blobServiceClient = null!;
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor used for injecting dependencies.
    /// </summary>
    /// <param name="context">The application database context.</param>
    /// <param name="config">The configuration settings.</param>
    public FileService(ApplicationDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    /// <inheritdoc/>
    public async Task UploadImageAsync(IFormFile image, Guid productId)
    {
        var url = await this.UploadImage(image);
        var product = await this._context.Products.FindAsync(productId);

        if (product is null)
        {
            throw new ArgumentException("Invalid productId");
        }

        product.ImageUrl = url;
        await this._context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    private async Task<string> UploadImage(IFormFile image)
    {
        var containerName = this._config[$"Azure:Storage:ContainerName"];
        var containerClient = this._blobServiceClient.GetBlobContainerClient(containerName);
        containerClient.CreateIfNotExists();

        BlockBlobClient blockBlobClient = containerClient.GetBlockBlobClient(
            Path.GetRandomFileName() + Guid.NewGuid().ToString() + Path.GetExtension(image.FileName).ToLowerInvariant());

        new FileExtensionContentTypeProvider().TryGetContentType(image.FileName, out var contentType);

        var blobHttpHeader = new BlobHttpHeaders { ContentType = (contentType ?? "application/octet-stream").ToLowerInvariant() };

        await blockBlobClient.UploadAsync(
            image.OpenReadStream(),
            new BlobUploadOptions { HttpHeaders = blobHttpHeader });

        return blockBlobClient.Uri.AbsoluteUri;
    }
}