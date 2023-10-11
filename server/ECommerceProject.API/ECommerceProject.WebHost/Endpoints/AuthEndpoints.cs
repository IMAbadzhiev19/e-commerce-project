using Carter;
using ECommerceProject.Data.Models.Auth;
using ECommerceProject.Services.Contracts.User;
using ECommerceProject.Services.Contracts.User.Auth;
using ECommerceProject.Shared.Models.User.Auth;
using ECommerceProject.Shared.Models.User.Auth.Token;
using ECommerceProject.WebHost.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerceProject.WebHost.Endpoints;

/// <summary>
/// Auth endpoints
/// </summary>
public class AuthEndpoints : ICarterModule
{
    /// <summary>
    /// Extension method that adds the auth endpoints
    /// </summary>
    /// <param name="app">IEndpointRouteBuilder</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
        app.MapPost("api/auth/login", async ([FromBody] LoginIM loginIM, ITokenService tokenService, IAuthService authService, IUserService userService) =>
        {
            try
            {
                var result = await userService.GetUserByEmailAsync(loginIM.Email);

                if (!await userService.CheckPasswordAsync(result.userId, loginIM.Password))
                {
                    throw new Exception("Invalid password");
                }
                
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
                return Results.Ok(new Response
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
            catch (NullReferenceException)
            {
                return Results.BadRequest(
                    new Response
                    {
                        Status = "register-failed",
                        Message = "An internal error occured duing the creation of the user"
                    });
            }
            catch (Exception e)
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
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "renew-tokens-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Auth");

        //app.MapGet("api/auth/confirm-email", async () =>
        //{

        //}).WithTags("Auth");

        //app.MapPost("api/auth/forgot-password", async () =>
        //{

        //}).WithTags("Auth");

        app.MapGet("api/auth/make-admin{id}", [Authorize(Roles = UserRoles.Admin)] async ([FromRoute] string id, IAuthService authService) =>
        {
            try
            {
                await authService.MakeAdminAsync(id);

                return Results.Ok(new Response
                {
                    Status = "make-admin-success",
                    Message = $"Successfully made user: \'{id}\' an admin",
                });
            }
            catch (Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "make-admin-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("Auth");
    }
}