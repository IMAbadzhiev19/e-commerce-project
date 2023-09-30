using Carter;

namespace ECommerceProject.WebHost.Endpoints;

public class UserEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("current-user", async () => { }).WithTags("User");
        
        app.MapPost("change-password", async () => { }).WithTags("User");
        
        app.MapPut("update-user-info", async () => { }).WithTags("User");
    }
}