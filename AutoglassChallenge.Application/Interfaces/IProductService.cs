using AutoglassChallenge.Domain.DTOs;
using AutoglassChallenge.Domain.Filters;

namespace AutoglassChallenge.Application.Interfaces
{
    public interface IProductService
    {
        public Task Create(ProductDto productDto);
        public Task Update(ProductDto productDto);
        public Task Delete(int productId);
        public Task<PaginatedDto<ProductDto>> GetByFilterPaginated(ProductFilter filter);
        public Task<ProductDto> GetById(int productId);

    }
}
