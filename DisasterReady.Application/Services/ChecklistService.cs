using DisasterReady.Application.Interfaces;
using DisasterReady.Domain.Entities;
using DisasterReady.Persistence.Interfaces;

namespace DisasterReady.Application.Services
{
    public class ChecklistService : IChecklistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChecklistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Checklist>> GetAllChecklistsAsync()
        {
            return await _unitOfWork.Checklists.GetAllAsync();
        }

        public async Task<Checklist?> GetChecklistByIdAsync(int id)
        {
            return await _unitOfWork.Checklists.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Checklist>> GetChecklistsByUserIdAsync(int userId)
        {
            return await _unitOfWork.Checklists.GetAsync(c => c.UserId == userId);
        }

        public async Task<Checklist> CreateChecklistAsync(Checklist checklist)
        {
            var createdChecklist = await _unitOfWork.Checklists.AddAsync(checklist);
            await _unitOfWork.SaveChangesAsync();
            return createdChecklist;
        }

        public async Task<bool> DeleteChecklistAsync(int id)
        {
            var checklist = await _unitOfWork.Checklists.GetByIdAsync(id);
            if (checklist == null) return false;
            _unitOfWork.Checklists.Delete(checklist);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<Checklist?> UpdateChecklistAsync(Checklist checklist)
        {
            var existing = await _unitOfWork.Checklists.GetByIdAsync(checklist.Id);
            if (existing == null) return null;
            existing.Title = checklist.Title;
            existing.Description = checklist.Description;
            existing.IsCompleted = checklist.IsCompleted;
            _unitOfWork.Checklists.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }

        public async Task<IEnumerable<ChecklistItem>> GetChecklistItemsAsync(int checklistId)
        {
            return await _unitOfWork.ChecklistItems.GetAsync(item => item.ChecklistId == checklistId);
        }

        public async Task<ChecklistItem> AddChecklistItemAsync(ChecklistItem item)
        {
            var createdItem = await _unitOfWork.ChecklistItems.AddAsync(item);
            await _unitOfWork.SaveChangesAsync();
            return createdItem;
        }

        public async Task<bool> RemoveChecklistItemAsync(int itemId)
        {
            var item = await _unitOfWork.ChecklistItems.GetByIdAsync(itemId);
            if (item == null) return false;
            _unitOfWork.ChecklistItems.Delete(item);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ChecklistItem?> UpdateChecklistItemAsync(ChecklistItem item)
        {
            var existing = await _unitOfWork.ChecklistItems.GetByIdAsync(item.Id);
            if (existing == null) return null;
            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.IsCompleted = item.IsCompleted;
            existing.Priority = item.Priority;
            _unitOfWork.ChecklistItems.Update(existing);
            await _unitOfWork.SaveChangesAsync();
            return existing;
        }
    }
} 