using Carter;
using ECommerceProject.Services.Contracts;
using ECommerceProject.Shared.Models.User;
using ECommerceProject.WebHost.Models;
using ECommerceProject.WebHost.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebHost.Endpoints;

public class UserEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("current-user", [Authorize] async (IUserService userService, ICurrentUser currentUser) =>
        {
            try
            {
                var user = await userService.GetUserByIdAsync(currentUser.UserId);
                return Results.Ok(user);
            }
            catch(ArgumentException e)
            {
                return Results.BadRequest(new Response 
                {
                    Status = "current-user-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("User");
        
        app.MapPost("change-password", [Authorize] async ([FromBody] ChangePasswordModel passwords, IUserService userService, ICurrentUser currentUser) =>
        {
            try
            {
                if (!await userService.CheckPasswordAsync(currentUser.UserId, passwords.OldPassword))
                    throw new Exception("Your old password is invalid");
                
                var identityResult = await userService.ChangePasswordAsync(currentUser.UserId, passwords.NewPassword);
                if (identityResult.Succeeded)
                    return Results.Ok(new Response
                    {
                        Status = "change-password-success",
                        Message = "User has changed password successfully",
                    });
                else
                    throw new Exception($"Password changing failed for user with id: {currentUser.UserId}");
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "change-password-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("User");
        
        app.MapPut("update-user-info", [Authorize] async ([FromBody] UserIM userIM, IUserService userService, ICurrentUser currentUser) =>
        {
            try
            {
                await userService.UpdateUserInfoAsync(currentUser.UserId, userIM);

                return Results.Ok(new Response
                {
                    Status = "update-user-success",
                    Message = "User info has been updated successfully",
                });
            }
            catch(Exception e)
            {
                return Results.BadRequest(new Response
                {
                    Status = "update-user-info-failed",
                    Message = e.Message,
                });
            }
        }).WithTags("User");
    }
}