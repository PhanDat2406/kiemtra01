namespace TechMart_Product_Manager.Models
{
    public class Product
    {
        public string ProductId { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string? ImagePath { get; set; }

        public Product() { }

        public Product(string productId, string productName, string categoryId, string categoryName, decimal unitPrice, int quantity, string? imagePath = null)
        {
            ProductId = productId;
            ProductName = productName;
            CategoryId = categoryId;
            CategoryName = categoryName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ImagePath = imagePath;
        }
    }
}
