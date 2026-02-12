namespace ProductsStarter.DTOs
{
    public class ProductResponseDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public int CartQuantity { get; set; }
        public bool IsAvailable { get; set; }
        public string? Description { get; set; }
    }
}
