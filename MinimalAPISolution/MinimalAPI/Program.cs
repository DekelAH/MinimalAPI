using Microsoft.EntityFrameworkCore;
using MinimalAPI.Core.Domain.RepositoryContracts;
using MinimalAPI.Core.ServiceContracts;
using MinimalAPI.Core.Services;
using MinimalAPI.Infrastructure.DatabaseContext;
using MinimalAPI.Infrastructure.Repositories;
using MinimalAPI.MapGroups;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductGetterRepository, ProductGetterRepository>();
builder.Services.AddScoped<IProductAdderRepository, ProductAdderRepository>();
builder.Services.AddScoped<IProductUpdaterRepository, ProductUpdaterRepository>();
builder.Services.AddScoped<IProductDeleterRepository, ProductDeleterRepository>();

builder.Services.AddScoped<IProductGetterService, ProductGetterService>();
builder.Services.AddScoped<IProductAdderService, ProductAdderService>();
builder.Services.AddScoped<IProductUpdaterService, ProductUpdaterService>();
builder.Services.AddScoped<IProductDeleterService, ProductDeleterService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

var mapGroup = app.MapGroup("/products").ProductsAPI();


app.Run();
