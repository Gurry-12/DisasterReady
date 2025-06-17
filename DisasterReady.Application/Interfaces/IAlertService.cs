using DisasterReady.Domain.Entities;
using DisasterReady.Shared.Enums;

namespace DisasterReady.Application.Interfaces
{
    public interface IAlertService
    {
        Task<IEnumerable<Alert>> GetAllAlertsAsync();
        Task<Alert?> GetAlertByIdAsync(int id);
        Task<IEnumerable<Alert>> GetAlertsByDisasterTypeAsync(int disasterTypeId);
        Task<IEnumerable<Alert>> GetAlertsBySeverityAsync(SeverityLevelEnum severity);
        Task<IEnumerable<Alert>> GetActiveAlertsAsync();
        Task<IEnumerable<Alert>> GetAlertsByRegionAsync(RegionEnum region);
        Task<IEnumerable<Alert>> GetRecentAlertsAsync(int count = 10);
        Task<Alert> CreateAlertAsync(Alert alert);
        Task<bool> DeleteAlertAsync(int id);
        Task<Alert?> UpdateAlertAsync(Alert alert);
    }
} 