using eCommerceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApi.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _context.Orders.Include(o => o.Products).ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) =>
            await _context.Orders.Include(o => o.Products)
                .FirstOrDefaultAsync(o => o.Id == id);

        public async Task AddAsync(Order order) =>
            await _context.Orders.AddAsync(order);

        public void Update(Order order) =>
            _context.Orders.Update(order);

        public void Remove(Order order) =>
            _context.Orders.Remove(order);

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Orders.AnyAsync(o => o.Id == id);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
