using AutoMapper;
using HelperStockBeta.Application.DTOs;
using HelperStockBeta.Application.Interfaces;
using HelperStockBeta.Domain.Entities;
using HelperStockBeta.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task AddProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task UpdateProduct(int id, ProductDTO productDTO)
        {
            var existingProduct = await _productRepository.GetByIdAsync(id);
            if (existingProduct == null)
            {
                // Tratar quando o produto não existe
                return;
            }

            _mapper.Map(productDTO, existingProduct);

            await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task RemoveProduct(int id)
        {
            var productEntity = await _productRepository.GetByIdAsync(id);
            if (productEntity == null)
            {
                // Tratar quando o produto não existe
                return;
            }

            await _productRepository.RemoveAsync(productEntity);
        }
    }
}
