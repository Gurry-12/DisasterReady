using System.Linq.Expressions;

namespace DisasterReady.Infrastructure.Repositories.AbstractRepositories
{
    public interface IRepository<T> where T : class
    {
        // Get all entities
        Task<IEnumerable<T>> GetAllAsync();
        
        // Get entity by ID
        Task<T?> GetByIdAsync(int id);
        
        // Get entities with filter
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter);
        
        // Get single entity with filter
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> filter);
        
        // Add entity
        Task<T> AddAsync(T entity);
        
        // Update entity
        void Update(T entity);
        
        // Delete entity
        void Delete(T entity);
        
        // Check if entity exists
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);
        
        // Count entities
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
    }
} 