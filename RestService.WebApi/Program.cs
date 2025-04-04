using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestService.Core;
using RestService.Core.Converters;
using RestService.Core.Dto;
using RestService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddOpenApi();

builder.Services.ConfigureHttpJsonOptions(options => 
{
    options.SerializerOptions.Converters.Add(new DataCreateDtoConverter());
});

builder.Services.AddDbContextPool<RestDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection")));

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILogger<RestDbContext>>();

await app.ApplyMigrationsIfNeededAsync(logger);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapPost("/api/data/get", async (
        IDataService service,
        [FromBody] DataFilterDto? filter,
        CancellationToken cancellationToken) =>
    {
        var data = await service.GetData(filter, cancellationToken);
        return data;
    })
    .WithName("GetData");

app.MapPost("/api/data/add", async (
        IDataService service,
        [FromBody] IEnumerable<DataCreateDto> dtos,
        CancellationToken cancellationToken) =>
    {
        await service.CreateData(dtos, cancellationToken);
    })
    .WithName("AddData");

app.Run();