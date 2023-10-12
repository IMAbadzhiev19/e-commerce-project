﻿using Carter;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints.ECommerceEndpoints;

/// <summary>
/// Cart endpoints
/// </summary>
public class CartEndpoints : ICarterModule
{
    /// <summary>
    /// Extension method that adds the cart endpoints
    /// </summary>
    /// <param name="app">IEndpointRouteBuilder</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/cart/create{userId}", [Authorize] async ([FromRoute] string userId, ICurrentUser currentUser, ICartService cartService) =>
        {
            try
            {
                var cartId = await cartService.CreateCart(currentUser.UserId);
                return Results.Ok(new Response
                {
                    Status = "create-success",
                    Message = cartId.ToString(),
                });
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "create-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Cart");

        app.MapPost("api/cart/assign-product", [Authorize] async ([FromQuery] Guid productId, [FromQuery] Guid cartId, ICartService cartService) =>
        {
            try
            {
                await cartService.AddProductToCart(productId, cartId);
                return Results.Ok(new Response
                {
                    Status = "assign-product-success",
                    Message = "You have successfully assigned a product to your cart",
                });
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "assign-product-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Cart");

        app.MapDelete("api/cart/remove-product", [Authorize] async ([FromQuery] Guid productId, [FromQuery] Guid cartId, ICartService cartService) =>
        {
            try
            {
                await cartService.RemoveProductFromCart(productId, cartId);
                return Results.Ok(new Response
                {
                    Status = "remove-product-success",
                    Message = "You have successfully removed a product to your cart",
                });
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "remove-product-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Cart");
    }
}