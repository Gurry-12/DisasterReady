using DisasterReady.Domain.Entities;

namespace DisasterReady.Infrastructure.Repositories.AbstractRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        // Repository properties
        IUserRepository Users { get; }
        IAlertRepository Alerts { get; }
        
        // Transaction methods
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
} 