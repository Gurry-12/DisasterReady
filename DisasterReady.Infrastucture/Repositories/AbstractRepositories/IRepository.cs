using System.Linq.Expressions;

namespace DisasterReady.Infrastructure.Repositories.AbstractRepositories
{
    public interface IRepository<T> where T : class
    {
        // Get all entities
        Task<IEnumerable<T>> GetAllAsync(bool asNoTracking = false);

        // Get entity by ID
        Task<T?> GetByIdAsync(int id, bool asNoTracking = false);

        // Get entities with filter
        Task<IEnumerable<T>> GetAsync(
            Expression<Func<T, bool>> filter,
            bool asNoTracking = false
        );

        // Get single entity with filter
        Task<T?> GetSingleAsync(
            Expression<Func<T, bool>> filter,
            bool asNoTracking = false
        );

        // Get entities with pagination and optional sorting
        Task<IEnumerable<T>> GetPagedAsync(
            int pageNumber,
            int pageSize,
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool asNoTracking = false
        );

        // Projection (select specific fields)
        Task<IEnumerable<TResult>> SelectAsync<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>>? filter = null,
            bool asNoTracking = false
        );

        // Add entity
        Task<T> AddAsync(T entity);

        // Add multiple entities
        Task AddRangeAsync(IEnumerable<T> entities);

        // Update entity
        void Update(T entity);

        // Update multiple entities
        void UpdateRange(IEnumerable<T> entities);

        // Delete entity
        void Delete(T entity);

        // Delete multiple entities
        void DeleteRange(IEnumerable<T> entities);

        // Check if entity exists
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);

        // Count entities
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);

        // Commit changes (if not using Unit of Work)
        Task<int> SaveChangesAsync();
    }
}
