using AutoMapper;
using eCommerceApi.DTOs.OrderDTOs;
using eCommerceApi.Models;
using eCommerceApi.Repositories.OrderRepository;
using eCommerceApi.Repositories.ProductRepository;

namespace eCommerceApi.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repo, IProductRepository productRepo, IMapper mapper)
        {
            _repo = repo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync()
        {
            var orders = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
            var order = await _repo.GetByIdAsync(id);
            return order == null ? null : _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto?> CreateAsync(CreateOrderDto dto)
        {
            var products = await _productRepo.GetAllAsync();
            var validProductIds = products.Select(p => p.Id).ToHashSet();

            if (dto.ProductIds.Any(id => !validProductIds.Contains(id)))
            {
                throw new ArgumentException("Invalid productId.");
            }

            var order = new Order
            {
                OrderDate = dto.OrderDate,
                Products = products.Where(p => dto.ProductIds.Contains(p.Id)).ToList()
            };

            await _repo.AddAsync(order);
            await _repo.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto?> UpdateAsync(int id, UpdateOrderDto dto)
        {
            var order = await _repo.GetByIdAsync(id);
            if (order == null) return null;

            var products = await _productRepo.GetAllAsync();
            var validProductIds = products.Select(p => p.Id).ToHashSet();

            if (dto.ProductIds.Any(id => !validProductIds.Contains(id)))
            {
                throw new ArgumentException("Invalid productId.");
            }

            order.OrderDate = dto.OrderDate;
            order.Products = products.Where(p => dto.ProductIds.Contains(p.Id)).ToList();

            _repo.Update(order);
            await _repo.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _repo.GetByIdAsync(id);
            if (order == null) return false;

            _repo.Remove(order);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
