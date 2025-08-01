using DisasterReady.Domain.Entities;
using DisasterReady.Infrastructure.Repositories.AbstractRepositories;
using DisasterReady.Infrastucture;
using DisasterReady.Persistence.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace DisasterReady.Infrastucture.ConcreteRepositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DisasterReadyDbContext _context;
        private IDbContextTransaction? _transaction;

        public IUserRepository Users { get; }
        public IAlertRepository Alerts { get; }
        public IRepository<Checklist> Checklists { get; }
        public IRepository<ChecklistItem> ChecklistItems { get; }
        public IRepository<Household> Households { get; }
        public IRepository<EmergencyTip> EmergencyTips { get; }
        public IRepository<Feedback> Feedbacks { get; }
        public IRepository<DisasterType> DisasterTypes { get; }
        public IRepository<RecommendationRule> RecommendationRules { get; }

        public UnitOfWork(DisasterReadyDbContext context,
            IUserRepository userRepository,
            IAlertRepository alertRepository,
            IRepository<Checklist> checklistRepository,
            IRepository<ChecklistItem> checklistItemRepository,
            IRepository<Household> householdRepository,
            IRepository<EmergencyTip> emergencyTipRepository,
            IRepository<Feedback> feedbackRepository,
            IRepository<DisasterType> disasterTypeRepository,
            IRepository<RecommendationRule> recommendationRuleRepository)
        {
            _context = context;
            Users = userRepository;
            Alerts = alertRepository;
            Checklists = checklistRepository;
            ChecklistItems = checklistItemRepository;
            Households = householdRepository;
            EmergencyTips = emergencyTipRepository;
            Feedbacks = feedbackRepository;
            DisasterTypes = disasterTypeRepository;
            RecommendationRules = recommendationRuleRepository;
        }

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
            _context.Dispose();
            _transaction?.Dispose();
        }
    }
} 