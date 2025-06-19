using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Infrastucture;
using DisasterReady.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DisasterReady.Infrastucture.ConcreteRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DisasterReadyDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository( DisasterReadyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
                return await _dbSet.CountAsync();
            return await _dbSet.CountAsync(filter);
        }
    }
} 