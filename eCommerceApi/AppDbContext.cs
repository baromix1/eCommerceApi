using Microsoft.EntityFrameworkCore;
using eCommerceApi.Models;

namespace eCommerceApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                       (e.State == EntityState.Added || e.State == EntityState.Modified));

            var utcNow = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = utcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedDate = utcNow;
                }
            }
        }
    }
}
