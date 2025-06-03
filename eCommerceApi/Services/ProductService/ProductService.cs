﻿using AutoMapper;
using eCommerceApi.DTOs.ProductDTOs;
using eCommerceApi.Models;
using eCommerceApi.Repositories.ProductRepository;

namespace eCommerceApi.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _repo.AddAsync(product);
            await _repo.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return null;

            _mapper.Map(dto, product);
            _repo.Update(product);
            await _repo.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return false;

            _repo.Remove(product);
            await _repo.SaveChangesAsync();
            return true;
        }
    }
}
