using DisasterReady.Domain.Entities;

namespace DisasterReady.Persistence.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Repository properties
        IUserRepository Users { get; }
        IAlertRepository Alerts { get; }
        IRepository<Checklist> Checklists { get; }
        IRepository<ChecklistItem> ChecklistItems { get; }
        IRepository<Household> Households { get; }
        IRepository<EmergencyTip> EmergencyTips { get; }
        IRepository<Feedback> Feedbacks { get; }
        IRepository<DisasterType> DisasterTypes { get; }
        IRepository<RecommendationRule> RecommendationRules { get; }

        // Transaction methods
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
} 