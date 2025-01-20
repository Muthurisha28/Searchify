using Microsoft.EntityFrameworkCore;
using Searchify.Core.Interfaces;
using Searchify.Core.Model;

namespace Searchify.DataAccessLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;
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
                var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                return product;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
