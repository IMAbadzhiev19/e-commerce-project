﻿using Carter;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints.ECommerceEndpoints;

public class WishlistEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/wishlist/create", [Authorize] async (ICurrentUser currentUser, IWishlistService wishlistService) =>
        {
            try
            {
                var wishlistId = await wishlistService.CreateWishlistAsync(currentUser.UserId);
                return Results.Ok(wishlistId);
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "create-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Wishlist");

        app.MapDelete("api/wishlist/remove{id}", [Authorize] async ([FromRoute] Guid id, ICurrentUser currentUser, IWishlistService wishlistService) =>
        {
            try
            {
                await wishlistService.RemoveWishlistAsync(id, currentUser.UserId);
                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "remove-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Wishlist");

        app.MapPut("api/wishlist/assign-product{wishlistId}", [Authorize] async ([FromRoute] Guid wishlistId, [FromQuery] Guid productId, ICurrentUser currentUser, IWishlistService wishlistService) =>
        {
            try
            {
                await wishlistService.AddProductToWishlistAsync(currentUser.UserId, productId, wishlistId);
                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "assign-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Wishlist");

        app.MapPut("api/wishlist/remove-product{wishlistId}", [Authorize] async ([FromRoute] Guid wishlistId, [FromQuery] Guid productId, ICurrentUser currentUser, IWishlistService wishlistService) =>
        {
            try
            {
                await wishlistService.RemoveProductFromWishlistAsync(currentUser.UserId, productId, wishlistId);
                return Results.Ok();
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "remove-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Wishlist");

        app.MapGet("api/wishlist/wishlists", [Authorize] async (ICurrentUser currentUser, IWishlistService wishlistService) =>
        {
            try
            {
                var wishlists = await wishlistService.GetWishlistsAsync(currentUser.UserId);
                return Results.Ok(wishlists);
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "wishlists-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Wishlist");
    }
}
