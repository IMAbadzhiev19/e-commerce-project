using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ECommerceProject.WebHost.Extensions;

/// <summary>
/// BearerConfiguration
/// </summary>
public static class BearerConfiguration
{
    /// <summary>
    /// Extension method that adds the bearer configuration
    /// </summary>
    /// <param name="services">The Service Collector</param>
    /// <param name="builder">The WebApplicationBuilder</param>
    public static void AddBearer(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata= false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!))
                };
            });
    }
}