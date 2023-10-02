using Carter;
using ECommerceProject.Services.Contracts.ECommerce;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Shared.Models.ECommerce;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints.ECommerceEndpoints;

public class ProductEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("product/request-product", async ([FromBody] ProductRM productRM, IProductService productService, ICurrentUser currentUser) =>
        {
            try
            {
                await productService.MakeProductRequestAsync(currentUser.UserId, productRM, productRM.Comments);

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

        app.MapGet("products/category{name}", async ([FromRoute] string categoryName, IProductService productService) =>
        {

        }).WithTags("Product");
    }
}
