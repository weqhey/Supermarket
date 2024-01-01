using Supermarket.Models;
using Supermarket.Data;
using Supermarket.Interfaces;

namespace Supermarket.Services
{
    public class GetProductsService : IGetProductsService
    {
        readonly SupermarketContext dbContext;
        public GetProductsService(SupermarketContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            IEnumerable<Product> products = from product in dbContext.Products select new Product { 
                ProductId = product.ProductId, 
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                Supplier = product.Supplier
            };
            return products;
        }
    }
}
