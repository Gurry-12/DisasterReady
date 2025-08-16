
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DisasterReady.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DisasterReadyDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(DisasterReadyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false)
        {
            var query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id, bool asNoTracking = false)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null && asNoTracking)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public async Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter,
            bool asNoTracking = false)
        {
            var query = _dbSet.Where(filter);
            if (asNoTracking) query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public async Task<T?> GetSingleAsync(
            Expression<Func<T, bool>> filter,
            bool asNoTracking = false)
        {
            var query = _dbSet.Where(filter);
            if (asNoTracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool asNoTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<TResult>> SelectAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>>? filter = null,
            bool asNoTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (asNoTracking)
                query = query.AsNoTracking();

            return await query.Select(selector).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbSet.AddRangeAsync(entities);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public void UpdateRange(IEnumerable<T> entities)
            => _dbSet.UpdateRange(entities);

        public void Delete(T entity)
            => _dbSet.Remove(entity);

        public void DeleteRange(IEnumerable<T> entities)
            => _dbSet.RemoveRange(entities);

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
            => await _dbSet.AnyAsync(filter);

        public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
            => filter == null ? await _dbSet.CountAsync() : await _dbSet.CountAsync(filter);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}
