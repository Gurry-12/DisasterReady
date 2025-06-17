using DisasterReady.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DisasterReady.Persistence.Data
{
    public class DisasterReadyDbContext : DbContext
    {
        public DisasterReadyDbContext(DbContextOptions<DisasterReadyDbContext> options) : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<User> Users { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<ChecklistItem> ChecklistItems { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<EmergencyTip> EmergencyTips { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<DisasterType> DisasterTypes { get; set; }
        public DbSet<RecommendationRule> RecommendationRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations from the Configurations folder
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DisasterReadyDbContext).Assembly);
        }
    }
} 