namespace eCommerceApi.DTOs.OrderDTOs
{
    public class UpdateOrderDto
    {
        public required DateTime OrderDate { get; set; }
        public required List<int> ProductIds { get; set; } = new List<int>();
    }
}
