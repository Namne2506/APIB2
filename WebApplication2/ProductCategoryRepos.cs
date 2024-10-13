using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2
{
    public class ProductCategoryRepos
    {
        private readonly ProductContext context;
        private readonly DbSet<ProductCategory> productCategories;

        public ProductCategoryRepos(ProductContext context, DbSet<ProductCategory> productCategories)
        {
            this.context = context;
            this.productCategories = productCategories;
        }

        public bool Create(ProductCategory productCategory)
        {
            try
            {
                productCategories.Add(productCategory);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<ProductCategory> GetAll()
        {
            return productCategories.ToList();
        }
        public bool GetProductById(int Id)
        {
            try
            {
                var FindProductCategory = productCategories.FirstOrDefault(p => p.Id == Id);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Update(ProductCategory productCategory)
        {
            try
            {
                var FindProductCategory = productCategories.FirstOrDefault(x => x.Id == productCategory.Id);
                FindProductCategory.Name = productCategory.Name;
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
                var FindProductCategory = productCategories.FirstOrDefault(p => p.Id == Id);

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
