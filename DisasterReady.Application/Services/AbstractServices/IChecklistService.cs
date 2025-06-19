using DisasterReady.Domain.Entities;

namespace DisasterReady.Application.Services.AbstractServices
{
    public interface IChecklistService
    {
        Task<IEnumerable<Checklist>> GetAllChecklistsAsync();
        Task<Checklist?> GetChecklistByIdAsync(int id);
        Task<IEnumerable<Checklist>> GetChecklistsByUserIdAsync(int userId);
        Task<Checklist> CreateChecklistAsync(Checklist checklist);
        Task<bool> DeleteChecklistAsync(int id);
        Task<Checklist?> UpdateChecklistAsync(Checklist checklist);
        Task<IEnumerable<ChecklistItem>> GetChecklistItemsAsync(int checklistId);
        Task<ChecklistItem> AddChecklistItemAsync(ChecklistItem item);
        Task<bool> RemoveChecklistItemAsync(int itemId);
        Task<ChecklistItem?> UpdateChecklistItemAsync(ChecklistItem item);
    }
} 