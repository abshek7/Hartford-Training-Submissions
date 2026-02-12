namespace ProductsStarter.DTOs
{
    public class ProductCreateDTO
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int CartQuantity { get; set; }
        public string? Description { get; set; }
    }
}
