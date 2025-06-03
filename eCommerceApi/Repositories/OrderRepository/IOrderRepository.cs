using eCommerceApi.Models;

namespace eCommerceApi.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task AddAsync(Order order);
        void Update(Order order);
        void Remove(Order order);
        Task<bool> ExistsAsync(int id);
        Task SaveChangesAsync();
    }
}
