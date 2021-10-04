using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using VBooX.Application.Interfaces;
using VBooX.Infrastructure.Persistence.Contexts;

namespace VBooX.Infrastructure.Persistence.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepositoryAsync(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public virtual async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync((object)id);

        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(
          int pageNumber,
          int pageSize)
        {
            return (IReadOnlyList<T>)await _dbContext.Set<T>().Skip<T>((pageNumber - 1) * pageSize).Take<T>(pageSize).AsNoTracking<T>().ToListAsync<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await _dbContext.Set<T>().AddAsync(entity);
            int num = await _dbContext.SaveChangesAsync(new CancellationToken());
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            int num = await _dbContext.SaveChangesAsync(new CancellationToken());
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            int num = await _dbContext.SaveChangesAsync(new CancellationToken());
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => (IReadOnlyList<T>)await _dbContext.Set<T>().ToListAsync<T>();

        public IQueryable<T> GetAll() => (IQueryable<T>)_dbContext.Set<T>();

        public IQueryable<T> GetAllIncluding(
          params Expression<Func<T, object>>[] propertySelectors)
        {
            IQueryable<T> source = _dbContext.Set<T>().AsQueryable();
            if (((IEnumerable<Expression<Func<T, object>>>)propertySelectors).Any<Expression<Func<T, object>>>())
            {
                foreach (Expression<Func<T, object>> propertySelector in propertySelectors)
                    source = (IQueryable<T>)source.Include<T, object>(propertySelector);
            }
            return source;
        }

        public async Task<int> CountAsync() => await _dbContext.Set<T>().CountAsync<T>();

        public async Task RemoveRange(List<T> entities)
        {
            _dbContext.Set<T>().RemoveRange((IEnumerable<T>)entities);
            int num = await _dbContext.SaveChangesAsync(new CancellationToken());
        }
    }
}