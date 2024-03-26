using AutoglassChallenge.Application.Interfaces;
using AutoglassChallenge.Application.Results;
using AutoglassChallenge.Domain.DTOs;
using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Filters;
using AutoglassChallenge.Domain.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AutoglassChallenge.Application.Services
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Create(ProductDto productDto)
        {
            var product = new Product(productDto);
            Validate(product);

            await _productRepository.Create(product);
        }

        private void Validate(Product product)
        {
            var validationResult = product.IsValid();
            if (validationResult != null && validationResult.Errors.Any())
            {
                throw new Exception(validationResult.Errors.First().ErrorMessage);
            }
        }

        public async Task Delete(int productId)
        {
            var product = await _productRepository.GetById(productId);

            if (product is null)
                return;

            product.Disable();

            await _productRepository.Update(product);
        }

        public async Task<PaginatedDto<ProductDto>> GetByFilterPaginated(ProductFilter filter)
        {
            var productsFiltered = await _productRepository.GetByFilter(filter);


            return new PaginatedDto<ProductDto>()
            {
                Items = BuildProductsDtos(productsFiltered.Items),
                ItemsByPage = productsFiltered.ItemsByPage,
                PageIndex = productsFiltered.PageIndex,
                TotalItems = productsFiltered.TotalItems
            };
        }

        public async Task<ProductDto> GetById(int productId)
        {
            var product = await _productRepository.GetById(productId);
            if (product is null)
                return null;

            return BuildProductDto(product);
        }

        public async Task Update(ProductDto productDto)
        {
            var product = await _productRepository.GetById(productDto.Id);

            if (product is null)
            {
                return;
            }

            product.Update(productDto);
            Validate(product);

            await _productRepository.Update(product);
        }

        private ProductDto BuildProductDto(Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                ManufacturingDate = product.ManufacturingDate,
                Description = product.Description,
                ExpirationDate = product.ExpirationDate,
                SupplierCNPJ = product.SupplierCNPJ,
                SupplierCode = product.SupplierCode,
                SupplierDescription = product.SupplierDescription,
            };
        }

        private IEnumerable<ProductDto> BuildProductsDtos(IEnumerable<Product> products)
        {
            return products.Select(x => BuildProductDto(x));
        }
    }
}
