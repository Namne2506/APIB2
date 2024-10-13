using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.ProductCategory).WithMany(a => a.products).HasForeignKey(p => p.ProductCategoryId);
        }
    }
}
