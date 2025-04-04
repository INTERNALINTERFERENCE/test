using Microsoft.EntityFrameworkCore;
using RestService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContextPool<RestDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/data", () =>
    {

    })
    .WithName("GetData");

app.MapPost("/api/data", () =>
    {

    })
    .WithName("AddData");

app.Run();