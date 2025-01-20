using Searchify.Core.Model;

namespace Searchify.Core.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
    }
}
