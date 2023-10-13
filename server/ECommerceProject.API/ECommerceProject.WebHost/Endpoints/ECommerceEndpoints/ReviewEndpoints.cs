﻿using Carter;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Shared.Models.ECommerce;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints.ECommerceEndpoints;

public class ReviewEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/review/create", [Authorize] async ([FromBody] ReviewIM reviewIM, ICurrentUser currentUser, IReviewService reviewService) =>
        {
            try
            {
                var reviewId = await reviewService.CreateReviewAsync(currentUser.UserId, reviewIM);
                return Results.Ok(reviewId);
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "create-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Review");

        app.MapDelete("api/review/remove{id}", [Authorize] async ([FromRoute] Guid id, ICurrentUser currentUser, IReviewService reviewService) =>
        {
            try
            {
                await reviewService.RemoveReviewAsync(currentUser.UserId, id);
                return Results.Ok();
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "remove-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Review");

        app.MapGet("api/review/reviews", [Authorize] async ([FromQuery] Guid productId, IReviewService reviewService) =>
        {
            try
            {
                var reviews = await reviewService.GetReviewsAsync(productId);
                return Results.Ok(reviews);
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "reviews-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Review");
    }
}
