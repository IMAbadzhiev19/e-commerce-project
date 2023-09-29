using Carter;
using ECommerceProject.Services.Contracts.Auth;
using ECommerceProject.Shared.Models.Auth;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerceProject.WebHost.Endpoints;

public class AuthEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/login", async ([FromBody] LoginIM loginIM, ITokenService tokenService, IAuthService authService) =>
        {
            var tokens = await tokenService.CreateTokensForUserAsync(loginIM.Email);

            return Results.Ok(new
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(tokens.AccessToken),
                RefreshToken = new JwtSecurityTokenHandler().WriteToken(tokens.RefreshToken),
                Expiration = tokens.AccessToken!.ValidTo,
            });
        }).WithTags("Auth");

        app.MapPost("api/auth/register", async ([FromBody] RegisterIM registerIM, IAuthService authService) =>
        {   
            try
            {
                await authService.CreateUserAsync(registerIM);
                
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

        app.MapGet("api/auth/logout", [Authorize] async () =>
        {
            return Results.Ok();
        }).WithTags("Auth");
    }
}