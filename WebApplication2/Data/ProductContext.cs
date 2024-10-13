using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext()
        {
        }

        public ProductContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

       
    }
}
