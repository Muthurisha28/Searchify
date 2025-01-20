using System.Collections.Generic;
using Searchify.Core.Model;

namespace Searchify.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);

    }
}
