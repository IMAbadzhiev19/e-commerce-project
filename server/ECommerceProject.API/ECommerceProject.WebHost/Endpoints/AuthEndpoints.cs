using Carter;
using ECommerceProject.Services.Contracts;
using ECommerceProject.Services.Contracts.Auth;
using ECommerceProject.Shared.Models.Auth;
using ECommerceProject.Shared.Models.Auth.Token;
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
                return Results.BadRequest(new Response
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
                
                return Results.Ok(new Response
                {
                    Status = "register-successful",
                    Message = "The user has been successfully registered"
                });
            }
            catch(NullReferenceException)
            {
                return Results.BadRequest(
                    new Response
                    {
                        Status = "register-failed",
                        Message = "An internal error occured duing the creation of the user"
                    });
            }
            catch(Exception e)
            {
                return Results.BadRequest(
                    new Response
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

                return Results.Ok(new Response
                {
                    Status = "logout-successful",
                    Message = "The user has been successfully logged out",
                });
            }
            catch (ArgumentException e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "logout-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Auth");

        app.MapPost("api/auth/renew-tokens", async ([FromBody] TokensIM tokensIM, ITokenService tokenService) =>
        {
            try
            {
                var newTokens = await tokenService.CreateNewTokensAsync(tokensIM);
                return Results.Ok(new
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(newTokens.AccessToken),
                    RefreshToken = new JwtSecurityTokenHandler().WriteToken(newTokens.RefreshToken),
                    Expiration = newTokens.AccessToken!.ValidTo,
                });
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "renew-tokens-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Auth");
    }
}