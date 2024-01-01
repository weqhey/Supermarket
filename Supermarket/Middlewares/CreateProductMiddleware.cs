using Supermarket.Models;
using Supermarket.Interfaces;
using Supermarket.Services;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Supermarket.Middlewares
{
    public class CreateProductMiddleware
    {
        private readonly RequestDelegate _next;

        public CreateProductMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICreateProductService service)
        {
            context.Response.ContentType = "text/html; charset=utf-8";

            // Check if the path is /addproduct
            if (context.Request.Path == "/addproduct")
            {
                // Check if the request method is POST
                if (context.Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
                {
                    var form = context.Request.Form;
                    Product product = new Product
                    {
                        Name = form["name"]
                    };

                    bool isValidInput = true;
                    string errorMessage = "";

                    // Convert and validate Price
                    if (decimal.TryParse(form["price"], out decimal price))
                    {
                        product.Price = price;
                    }
                    else
                    {
                        isValidInput = false;
                        errorMessage += "Invalid price format. ";
                    }

                    // Convert and validate CategoryId
                    if (int.TryParse(form["category_id"], out int categoryId))
                    {
                        product.CategoryId = categoryId;
                    }
                    else
                    {
                        isValidInput = false;
                        errorMessage += "Invalid category ID format. ";
                    }

                    // Convert and validate SupplierId
                    if (int.TryParse(form["supplier_id"], out int supplierId))
                    {
                        product.SupplierId = supplierId;
                    }
                    else
                    {
                        isValidInput = false;
                        errorMessage += "Invalid supplier ID format. ";
                    }

                    if (isValidInput)
                    {
                        // Add product and redirect to products page
                        service.AddProduct(product);
                        context.Response.Redirect("/products");
                    }
                    else
                    {
                        // Redirect back to the form with an error message
                        context.Response.Redirect($"/form?error={Uri.EscapeDataString(errorMessage)}");
                    }
                }
                else
                {
                    // If it's not a POST request, redirect to the form
                    context.Response.Redirect("/form");
                }
            }
            else
            {
                if (context.Request.Path == "/form")
                {
                    await context.Response.SendFileAsync("html/CreateProduct.html");
                }

                await _next(context);
            }
        }
    }
}