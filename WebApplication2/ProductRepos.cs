using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2
{
    public class ProductRepos
    {
        private readonly ProductContext context;
        private readonly DbSet<Product> products;

        public ProductRepos(ProductContext context, DbSet<Product> products)
        {
            this.context = context;
            this.products = products;
        }
        public bool Create(Product product)
        {
            try
            {
                products.Add(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Product> GetAll()
        {
            try
            {
                return products.ToList();
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }
        public bool GetProductById(int Id)
        {
            try
            {
                var productFind = products.FirstOrDefault(p => p.Id == Id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Update(Product product)
        {
            try
            {
                var productFind = products.FirstOrDefault(x => x.Id == product.Id);
                    product.Name = product.Name;
                    product.Describe = product.Describe;
                    product.Price = product.Price;
                    product.ProductCategoryId = product.ProductCategoryId;
                    product.Inventory = product.Inventory;
                    context.SaveChanges();
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool Delete(int Id)
        {
            try
            {
                var productFind = products.FirstOrDefault(p => p.Id == Id);
               
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
