using AutoglassChallenge.Domain.DTOs;
using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Filters;
using AutoglassChallenge.Domain.Interfaces;
using AutoglassChallenge.Intra.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AutoglassChallenge.Intra.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PaginatedDto<Product>> GetByFilter(ProductFilter filter)
        {
            var query = _dbContext.Set<Product>()
                .AsQueryable();

            query = ApplyFilter(filter, query);
            var totalItems = query.Count();

            query = ApplyPagination(filter, query);
            var products = await query.ToListAsync();

            return new PaginatedDto<Product>
            {
                Items = products,
                TotalItems = totalItems,
                ItemsByPage = filter.ItemsByPage,
                PageIndex = filter.PageIndex
            };
        }

        private static IQueryable<Product> ApplyPagination(ProductFilter filter, IQueryable<Product> query)
        {
            return query.Skip((filter.PageIndex - 1) * filter.ItemsByPage)
                            .Take(filter.ItemsByPage);
        }

        private IQueryable<Product> ApplyFilter(ProductFilter filter, IQueryable<Product> query)
        {
            if (filter.Status.HasValue)
                query = query.Where(x => x.Status == filter.Status);
            if (filter.Description != null)
                query = query.Where(x => x.Description.Contains(filter.Description));
            if (filter.ManufacturingDate.HasValue)
                query = query.Where(x => x.ManufacturingDate.Date == filter.ManufacturingDate);
            if (filter.ExpirationDate.HasValue)
                query = query.Where(x => x.ExpirationDate.Date == filter.ExpirationDate);
            if (filter.SupplierCode != null)
                query = query.Where(x => x.SupplierCode == filter.SupplierCode);
            if (filter.SupplierDescription != null)
                query = query.Where(x => x.SupplierDescription.Contains(filter.SupplierDescription));
            if (filter.SupplierCNPJ != null)
                query = query.Where(x => x.SupplierCNPJ.Contains(filter.SupplierCNPJ));
            return query;
        }

        public override async Task<Product> GetById(int productId)
        {
            return await _dbContext.Set<Product>()
                .FirstOrDefaultAsync(x => x.Id == productId);
        }
    }
}
