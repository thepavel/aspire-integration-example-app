using eShop.Catalog.API;
using eShop.Catalog.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddDefaultOpenApi();
builder.AddApplicationServices();

builder.Services.AddProblemDetails();

builder.AddNpgsqlDbContext<CatalogDbContext>("CatalogDB");
builder.AddRedisDistributedCache("cache");

var app = builder.Build();

app.UseDefaultOpenApi();

app.MapDefaultEndpoints();

app.MapGroup(app.GetOptions<CatalogOptions>().ApiBasePath)
    .WithTags("Catalog API")
    .MapCatalogApi();

app.Run();
