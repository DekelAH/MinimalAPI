using MinimalAPI.MapGroups;
using MinimalAPI.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

var mapGroup = app.MapGroup("/products").ProductsAPI();


app.Run();
