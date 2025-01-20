using Searchify.Core.Interfaces;
using Searchify.Core.Model;

namespace Searchify.BusinessLayer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return await _productRepository.GetAllProducts();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetProductById(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
