namespace eCommerceApi.Models
{
    public class Order : BaseEntity
    {
        public required DateTime OrderDate { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
