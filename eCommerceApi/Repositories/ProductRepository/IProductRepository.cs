using eCommerceApi.Models;

namespace eCommerceApi.Repositories.ProductRepository

{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        void Update(Product product);
        void Remove(Product product);
        Task<bool> ExistsAsync(int id);
        Task SaveChangesAsync();
    }
}
