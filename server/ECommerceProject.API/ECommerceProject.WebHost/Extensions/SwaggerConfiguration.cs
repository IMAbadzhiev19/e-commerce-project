﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace ECommerceProject.WebHost.Extensions;

/// <summary>
/// Swagger configuration
/// </summary>
public static class SwaggerConfiguration
{
    /// <summary>
    /// Extension method that adds swagger configuration
    /// </summary>
    /// <param name="services">The Service Collector</param>
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            
            options.OperationFilter<SecurityRequirementsOperationFilter>();
            
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "JobHunter API",
                Description = "An ECommerce API",
            });

            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}