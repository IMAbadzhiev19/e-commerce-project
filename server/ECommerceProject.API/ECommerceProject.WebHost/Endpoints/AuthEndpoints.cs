using Carter;
using ECommerceProject.Services.Contracts.Auth;
using ECommerceProject.Shared.Models.Auth;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using ECommerceProject.Services.Contracts;

namespace ECommerceProject.WebHost.Endpoints;

public class AuthEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/login", async ([FromBody] LoginIM loginIM, ITokenService tokenService, IAuthService authService) =>
        {
            try
            {
                var tokens = await tokenService.CreateTokensForUserAsync(loginIM.Email);

                return Results.Ok(new
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(tokens.AccessToken),
                    RefreshToken = new JwtSecurityTokenHandler().WriteToken(tokens.RefreshToken),
                    Expiration = tokens.AccessToken!.ValidTo,
                });
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Result
                {
                    Status = "login-failed",
                    Message = e.Message,
                });
            }
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

        app.MapGet("api/auth/logout", [Authorize] async (ICurrentUser currentUser, ITokenService tokenService) =>
        {
            try
            {
                await tokenService.DeleteRefreshTokenAsync(currentUser.UserId);

                return Results.Ok(new Result
                {
                    Status = "logout-successful",
                    Message = "The user has been successfully logged out",
                });
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new Result
                {
                    Status = "logout-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Auth");
    }
}