using Carter;
using ECommerceProject.Data.Data;
using ECommerceProject.WebHost.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//Configures DbContext
builder.Services.AddDbContext<ApplicationDbContext>(o =>
{
    o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!, o =>
    {
        o.MigrationsAssembly(typeof(Program).Assembly.FullName);
        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        o.UseDateOnlyTimeOnly();
    });
});

//Configures Cors
builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(config =>
    {
        config
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//Configures Swagger + Identity and Bearer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentity();
builder.Services.AddSwagger();
builder.Services.AddBearer(builder);

builder.Services.AddCarter();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapCarter();

app.Run();