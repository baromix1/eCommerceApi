namespace eCommerceApi.Models
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
