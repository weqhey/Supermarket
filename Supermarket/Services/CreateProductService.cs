using Supermarket.Models;
using Supermarket.Data;
using Supermarket.Interfaces;

namespace Supermarket.Services
{
    public class CreateProductService : ICreateProductService
    {
        readonly SupermarketContext dbContext;
        public CreateProductService(SupermarketContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
        }
    }
}
