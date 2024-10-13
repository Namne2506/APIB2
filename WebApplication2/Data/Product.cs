    namespace WebApplication2.Data
{
    public class Product
    {
        public int Id { get; set; } //id
        public string Name  { get; set; } // tên
        public string Describe { get; set; } // mô tả

        public int Price { get; set; } // Giá
        public int Inventory { get; set; } // Hàng tồn kho
        public int ProductCategoryId { get; set; } // danh mục sản phẩm
        
        public ProductCategory ProductCategory { get; set; }

    }
}
