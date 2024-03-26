using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Interfaces;
using AutoglassChallenge.Intra.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace AutoglassChallenge.Intra.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}



