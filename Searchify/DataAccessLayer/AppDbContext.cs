using Microsoft.EntityFrameworkCore;
using Searchify.Core.Model;

namespace Searchify.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
