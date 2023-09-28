using Carter;

namespace ECommerceProject.WebHost.Endpoints;

public class AuthEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/auth/login", async () =>
        {

        }).WithTags("Auth");

        app.MapPost("api/auth/register", async () =>
        {
            
        }).WithTags("Auth");

        app.MapGet("api/auth/logout", async () =>
        {

        }).WithTags("Auth");
    }
}