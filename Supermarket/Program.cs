using Library.Middlewares;
using Microsoft.EntityFrameworkCore;
using Supermarket.Data;
using Supermarket.Interfaces;
using Supermarket.Middlewares;
using Supermarket.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SupermarketContext>(options =>
{
    options.UseInMemoryDatabase("InMemoryDb");
});

builder.Services.AddTransient<IGetProductsService, GetProductsService>();
builder.Services.AddTransient<ICreateProductService, CreateProductService>();

var app = builder.Build();

app.UseMiddleware<GetProductsMiddleware>();
app.UseMiddleware<CreateProductMiddleware>();

app.UseHttpsRedirection();
app.Run();