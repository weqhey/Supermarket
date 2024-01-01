using Supermarket.Models;
using Supermarket.Interfaces;
using Newtonsoft.Json;

namespace Library.Middlewares
{
    public class GetProductsMiddleware
    {
        private readonly RequestDelegate _next;

        public GetProductsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IGetProductsService service)
        {
            if (context.Request.Path == "/products")
            {
                var productList = service.GetProducts().Select(product => new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    Supplier = product.Supplier
                }).ToList();

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Formatting = Formatting.Indented // Enable pretty print
                };

                var json = JsonConvert.SerializeObject(productList, settings);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(json);
            }
            else
            {
                await _next(context);
            }
        }
    }
}
