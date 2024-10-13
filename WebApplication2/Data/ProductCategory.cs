namespace WebApplication2.Data
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> products { get; set; }
    }
}
