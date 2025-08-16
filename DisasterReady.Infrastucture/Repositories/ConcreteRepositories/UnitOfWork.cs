using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace DisasterReady.Infrastructure.Repositories.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DisasterReadyDbContext _context;
        private IDbContextTransaction? _currentTransaction;

        public IUserRepository Users { get; }
        public IAlertRepository Alerts { get; }

        public UnitOfWork(
            DisasterReadyDbContext context,
            IUserRepository users,
            IAlertRepository alerts
        )
        {
            _context = context;
            Users = users;
            Alerts = alerts;
        }


        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null) return;
            _currentTransaction = await _context.Database.BeginTransactionAsync();
        }
        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                if (_currentTransaction != null)
                {
                    await _currentTransaction.CommitAsync();
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                await _currentTransaction.RollbackAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _currentTransaction?.Dispose();
        }
    }
}
