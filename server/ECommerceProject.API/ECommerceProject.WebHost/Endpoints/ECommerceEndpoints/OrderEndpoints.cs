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
/// Represents the class for defining order-related endpoints.
/// </summary>
public class OrderEndpoints : ICarterModule
{
    /// <summary>
    /// Adds the routes for creating a new order.
    /// </summary>
    /// <param name="app">The IEndpointRouteBuilder instance.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/order/create", [Authorize] async ([FromBody] OrderIM orderIM, IOrderService orderService, ICurrentUser currentUser) =>
        {
            try
            {
                var orderId = await orderService.CreateOrderAsync(currentUser.UserId, orderIM);
                return Results.Ok(orderId);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new Response
                {
                    Status = "create-failed",
                    Message = ex.Message
                });
            }
        }).WithTags("Order");
        
        app.MapDelete("api/order/remove{id}", [Authorize] async ([FromRoute] Guid id, IOrderService orderService, ICurrentUser currentUser) =>
        {
            try
            {
                await orderService.RemoveOrderAsync(currentUser.UserId, id);

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new Response
                {
                    Status = "delete-failed",
                    Message = ex.Message
                });
            }
        }).WithTags("Order");
        
        app.MapGet("api/order/orders", [Authorize] async (IOrderService orderService, ICurrentUser currentUser) =>
        {
            try
            {
                var orders = await orderService.GetOrdersAsync(currentUser.UserId);

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new Response
                {
                    Status = "get-failed",
                    Message = ex.Message
                });
            }
        }).WithTags("Order");
    }
}