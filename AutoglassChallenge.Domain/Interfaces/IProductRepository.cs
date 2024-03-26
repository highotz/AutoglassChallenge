using AutoglassChallenge.Domain.DTOs;
using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Filters;

namespace AutoglassChallenge.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<PaginatedDto<Product>> GetByFilter(ProductFilter filter);
    }
}
