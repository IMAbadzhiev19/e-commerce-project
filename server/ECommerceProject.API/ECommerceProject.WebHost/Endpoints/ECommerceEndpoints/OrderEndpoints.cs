using Carter;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Shared.Models.ECommerce;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints.ECommerceEndpoints;

public class OrderEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/order/create", [Authorize] async ([FromBody] OrderIM orderIM,IOrderService orderService, ICurrentUser currentUser) =>
        {
            try
            {
                var order = await orderService.CreateOrder(currentUser.UserId, orderIM);

                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(new Response {
                    Status = "create-failed",
                    Message = ex.Message
                });
            }
        }).WithTags("Order");

        app.MapDelete("api/order/delete{orderId}", [Authorize] async ([FromBody] Guid orderId, IOrderService orderService, ICurrentUser currentUser) =>
        {
            try
            {
                await orderService.RemoveOrder(currentUser.UserId,orderId);

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


        app.MapDelete("api/order/get", [Authorize] async (IOrderService orderService, ICurrentUser currentUser) =>
        {
            try
            {
                var comments = await orderService.GetOrders(currentUser.UserId);

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
