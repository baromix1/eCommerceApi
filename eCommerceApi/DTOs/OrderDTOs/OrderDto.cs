using eCommerceApi.DTOs.ProductDTOs;

namespace eCommerceApi.DTOs.OrderDTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
