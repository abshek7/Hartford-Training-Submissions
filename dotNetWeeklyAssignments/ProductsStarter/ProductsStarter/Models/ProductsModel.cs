namespace ProductsStarter.Models
{
    public class ProductsModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int CartQuantity { get; set; }
        public bool isAvailable => CartQuantity > 0;
        public string? Description { get; set; } = string.Empty;
    }
}
