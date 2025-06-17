using DisasterReady.Persistence.Interfaces;
using DisasterReady.Persistence.Data;
using DisasterReady.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace DisasterReady.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DisasterReadyDbContext _context;
        private IDbContextTransaction? _transaction;

        // Repository instances
        private IUserRepository? _users;
        private IAlertRepository? _alerts;
        private IRepository<Checklist>? _checklists;
        private IRepository<ChecklistItem>? _checklistItems;
        private IRepository<Household>? _households;
        private IRepository<EmergencyTip>? _emergencyTips;
        private IRepository<Feedback>? _feedbacks;
        private IRepository<DisasterType>? _disasterTypes;
        private IRepository<RecommendationRule>? _recommendationRules;

        public UnitOfWork(DisasterReadyDbContext context)
        {
            _context = context;
        }

        // Repository properties
        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IAlertRepository Alerts => _alerts ??= new AlertRepository(_context);
        public IRepository<Checklist> Checklists => _checklists ??= new Repository<Checklist>(_context);
        public IRepository<ChecklistItem> ChecklistItems => _checklistItems ??= new Repository<ChecklistItem>(_context);
        public IRepository<Household> Households => _households ??= new Repository<Household>(_context);
        public IRepository<EmergencyTip> EmergencyTips => _emergencyTips ??= new Repository<EmergencyTip>(_context);
        public IRepository<Feedback> Feedbacks => _feedbacks ??= new Repository<Feedback>(_context);
        public IRepository<DisasterType> DisasterTypes => _disasterTypes ??= new Repository<DisasterType>(_context);
        public IRepository<RecommendationRule> RecommendationRules => _recommendationRules ??= new Repository<RecommendationRule>(_context);

        // Transaction methods
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
} 