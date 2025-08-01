using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Infrastructure.Repositories.AbstractRepositories
{
    public interface IAlertRepository : IRepository<Alert>
    {
        // Get alerts by disaster type
        Task<IEnumerable<Alert>> GetByDisasterTypeAsync(int disasterTypeId);
        
        // Get alerts by severity level
        Task<IEnumerable<Alert>> GetBySeverityAsync(SeverityLevelEnum severity);
        
        // Get active alerts
        Task<IEnumerable<Alert>> GetActiveAlertsAsync();
        
        // Get alerts by region
        Task<IEnumerable<Alert>> GetByRegionAsync(RegionEnum region);
        
        // Get recent alerts
        Task<IEnumerable<Alert>> GetRecentAlertsAsync(int count = 10);
    }
} 