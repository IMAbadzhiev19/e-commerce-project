using Carter;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;
using ECommerceProject.WebHost.Models;
using ECommerceProject.Data.Data;
using ECommerceProject.Services.Contracts;

namespace ECommerceProject.WebHost.Endpoints;

public class AuthEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/login", async () =>
        {

        }).WithTags("Auth");

        app.MapPost("api/auth/register", async (/*[FromForm]*/ RegisterIM registerIM, IAuthService authService) =>
        {
            try
            {
                await authService.CreateUser(registerIM);
                return Results.Ok(new Result
                {
                    Status = "register-successful",
                    Message = "The user has been successfully registered"
                });
            }
            catch(NullReferenceException)
            {
                return Results.BadRequest(
                    new Result
                    {
                        Status = "register-failed",
                        Message = "An internal error occured duing the creation of the user"
                    });
            }
            catch(Exception e)
            {
                return Results.BadRequest(
                    new Result
                    {
                        Status = "register-failed",
                        Message = e.Message
                    });
            }
        }).WithTags("Auth");

        app.MapGet("api/auth/logout", async () =>
        {

        }).WithTags("Auth");
    }
}