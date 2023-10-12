using Carter;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Shared.Models.ECommerce;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints.ECommerceEndpoints;

/// <summary>
/// Comment Endpoints
/// </summary>
public class CommentEndpoints : ICarterModule
{
    /// <summary>
    /// Extension method that adds the comment endpoints
    /// </summary>
    /// <param name="app">IEndpointRouteBuilder</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/comment/create", [Authorize] async ([FromBody] CommentIM commentIM, ICommentService commentService, ICurrentUser currentUser) =>
        {
            try
            {
                var commentId = await commentService.CreateComment(currentUser.UserId, commentIM);

                return Results.Ok(commentId);
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "create-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Comment");

        app.MapDelete("api/comment/remove{id}", [Authorize] async ([FromRoute] Guid id, ICurrentUser currentUser, ICommentService commentService) =>
        {
            try
            {
                await commentService.RemoveComment(currentUser.UserId, id);
                return Results.Ok(new Response
                {
                    Status = "remove-success",
                    Message = "Successfully removed the comment",
                });
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "remove-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Comment");

        app.MapGet("api/comment/comments{productId}", [Authorize] async ([FromRoute] Guid productId, ICommentService commentService) =>
        {
            try
            {
                var comments = await commentService.GetComments(productId);
                return Results.Ok(comments);
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "comments-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Comment");
    }
}