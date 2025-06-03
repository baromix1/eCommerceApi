namespace eCommerceApi.DTOs.ProductDTOs
{
    public class CreateProductDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}