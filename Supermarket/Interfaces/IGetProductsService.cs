using Supermarket.Models;

namespace Supermarket.Interfaces
{
    public interface IGetProductsService
    {
        public IEnumerable<Product> GetProducts();
    }
}
