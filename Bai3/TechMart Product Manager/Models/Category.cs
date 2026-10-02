namespace TechMart_Product_Manager.Models
{
    public class Category
    {
        public string CategoryId { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;

        public Category() { }

        public Category(string categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
