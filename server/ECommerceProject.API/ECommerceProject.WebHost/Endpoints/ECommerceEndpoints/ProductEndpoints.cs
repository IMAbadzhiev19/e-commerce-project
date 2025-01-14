﻿using Carter;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Data.Models.Enums;
using ECommerceProject.Services.Contracts;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Shared.Models.ECommerce;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints.ECommerceEndpoints;

/// <summary>
/// Product Endpoints
/// </summary>
public class ProductEndpoints : ICarterModule
{
    /// <summary>
    /// Extension method that adds the product endpoints
    /// </summary>
    /// <param name="app">IEndpointRouteBuilder</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/products/request-product", [Authorize] async ([FromBody] ProductRM productRM, IEmailService emailService, ICurrentUser currentUser) =>
        {
            try
            {
                await emailService.SendProductRequestAsync(productRM);

                return Results.Ok(new Response
                {
                    Status = "request-product-success",
                    Message = "Successfully requested a product",
                });
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "request-product-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Product");

        app.MapGet("api/products/category", [Authorize] async ([FromBody] CategoryIM categoryIM, IProductService productService) =>
        {
            try
            {   
                var products = await productService
                    .GetProductsByCategoryAsync(
                        Enum.Parse<Categories>(categoryIM.Name)
                    );

                return Results.Ok(products);
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Product");

        app.MapPost("api/products/upload-image{id}", [Authorize(Roles = UserRoles.Admin)] async ([FromRoute] Guid id, [FromForm] IFormFile image, IFileService fileService) =>
        {
            try
            {
                await fileService.UploadImageAsync(image, id);

                return Results.Ok(new Response
                {
                    Status = "upload-image-success",
                    Message = "Successfully uploaded image",
                });
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "upload-image-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Product");

        app.MapPut("api/products/update{id}", [Authorize(Roles = UserRoles.Admin)] async ([FromRoute] Guid id, [FromBody] ProductUM productUM , IProductService productService) =>
        {
            try
            {
                await productService.UpdateProductAsync(id, productUM);
                return Results.Ok(new Response
                {
                    Status = "update-product-success",
                    Message = $"Successfully updated the product with id {id}",
                });
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "update-product-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Product");

        app.MapGet("api/products/get-product{id}", [Authorize] async ([FromRoute] Guid id, IProductService productService) =>
        {
            try
            {
                var product = await productService.GetProductByIdAsync(id);
                return Results.Ok(product);
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "get-product-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Product");

        app.MapGet("api/products/get-products", [Authorize] async (IProductService productService) =>
        {
            try
            {
                var products = await productService.GetProducts();
                return Results.Ok(products);
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "get-product-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Product");

        app.MapPost("api/products/create", [Authorize] async ([FromBody] ProductIM product,IProductService productService) =>
        {
            try
            {
                var newProduct = await productService.CreateProduct(product);
                return Results.Ok(newProduct);
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "create-product-failed", 
                    Message = e.Message,
                });
            }
        }).WithTags("Product");
    }
}