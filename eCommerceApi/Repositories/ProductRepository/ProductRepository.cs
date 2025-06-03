using Microsoft.EntityFrameworkCore;
using eCommerceApi.Models;

namespace eCommerceApi.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
            await _context.Products.ToListAsync();

        public async Task<Product?> GetByIdAsync(int id) =>
            await _context.Products.FindAsync(id);

        public async Task AddAsync(Product product) =>
            await _context.Products.AddAsync(product);

        public void Update(Product product) =>
            _context.Products.Update(product);

        public void Remove(Product product) =>
            _context.Products.Remove(product);

        public async Task<bool> ExistsAsync(int id) =>
            await _context.Products.AnyAsync(p => p.Id == id);

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
